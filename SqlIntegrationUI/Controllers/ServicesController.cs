using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SysFile = System.IO.File;
using Microsoft.CodeAnalysis;
using CommonCode.Models.Dtos.Requests;
using CommonCode.Models.Dtos.Responses;
using CommonCode.Models.Dtos;
using CommonCode.CommonClasses;
using static CommonCode.CommonClasses.Common;
using System.Text;
using AutoMapper;
using Column = CommonCode.CommonClasses.Column;

namespace SqlIntegrationUI.Controllers
{
    //[Route("[Controller]")]
    public class ServicesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ServicesController> logger;
        private readonly IHttpClientFactory HttpClientFactory;
        private readonly HttpClient Client;

        public ServicesController(IHttpClientFactory httpClientFactory, IMapper mapper, ILogger<ServicesController> logger)
        {
            ArgumentNullException.ThrowIfNull(httpClientFactory);
            try
            {
                HttpClientFactory = httpClientFactory;
                Client = HttpClientFactory.CreateClient();
                _mapper = mapper;
                this.logger = logger;
                //if (ConfigServices is null)
                //{
                //    Log("ConfigServices not found");
                //    ConfigServices = new Services { ServiceSet = [] };

                //    //throw new Exception("ConfigServices not found")};
                //}ed
                //    ViewData["SuccessMessage"] = Emp;
                //    ViewData["ErrorMessage"] = Emp;
                //    ViewData["Message"] = Emp;
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? searchString)
        {
            try
            {
                List<ServiceDto> result = null;
                try
                {
                    //var services = await _serviceRepository.GetAllAsync();
                    using HttpResponseMessage response = await Client.GetAsync($"{ApiBaseUrl}");
                    if (response == null)
                    {
                        Log("ConfigServices could not be loaded!");
                        //return Problem("ConfigServices could not be loaded!");
                        return View();
                    }
                    //response.EnsureSuccessStatusCode();
                    if (!response.IsSuccessStatusCode)
                    {
                        string msg = $"HTTP request failed with status code: {response.StatusCode}";
                        Log(msg);
                        //return Problem("ConfigServices could not be loaded!");
                        return View();
                    }
                    result = await response.Content.ReadFromJsonAsync<List<ServiceDto>>();
                }
                catch (Exception)
                { }
                if (!(result?.Count > 0))
                {
                    Log("Services not found!");
                    //return Problem("ConfigServices could not be loaded!");
                    return View();
                }
                IEnumerable<ServiceDto> genreQry = from service in result orderby service.Name select service;

                if (genreQry is null || !genreQry.Any()) return View();

                List<ServiceDto> ServiceListOrgnl = genreQry.Distinct().ToList();

                if (!string.IsNullOrEmpty(searchString))
                    genreQry = genreQry.Where(s => s.Name!.Contains(searchString));

                var ServiceListFltrd = genreQry.Distinct().ToList();
                ViewData["ServiceSet"] = new SelectList(ServiceListOrgnl, "Name", "Name");
                ViewData["ServiceListFltrd"] = new SelectList(ServiceListFltrd, "Name", "Name");

                List<List<ServiceDto>> lst = [ServiceListOrgnl, ServiceListFltrd];
                return View(lst);
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string Endpoint, string colSearch)
        {
            List<Column> lst;
            ServiceDto? service = null;
            if (IsEmpty(Endpoint))
                return NotFound();
            try
            {
                //ServiceDetail service = ConfigServices.ServiceSet.First(s => s.Endpoint == Endpoint);
                try
                {
                    using HttpResponseMessage response = await Client.GetAsync($"{ApiBaseUrl}/{Endpoint}");

                    if (response == null)
                    {
                        Log("Requested service could not be loaded!");
                        //return Problem("ConfigServices could not be loaded!");
                        return View();
                    }
                    //response.EnsureSuccessStatusCode();
                    if (!response.IsSuccessStatusCode)
                    {
                        string msg = $"HTTP request failed with status code: {response.StatusCode}";
                        Log(msg);
                        //return Problem("ConfigServices could not be loaded!");
                        return View();
                    }
                    var rslt = await response.Content.ReadFromJsonAsync<List<ServiceDto>>();

                    service = rslt[0];
                }
                catch (Exception)
                { }
                if (service is null)
                {
                    Log("Services not found!");
                    //return Problem("ConfigServices could not be loaded!");
                    return View();
                }

                if (service.Columns is null)
                {
                    //ConfigServices.ServiceSet.Remove(service);
                    lst = await GetColumns(null, service) ?? [];
                    //service.Columns ??= lst;
                    //ConfigServices.ServiceSet.Add(service);
                }
                else
                    lst = DeserializeJson<List<Column>>.Deserialize(service.Columns);
                //lst = DeserializeJson<List<Column>>.Deserialize(service.Columns);

                lst = lst.OrderBy(c => c?.Name)?.ToList();

                ViewData["ColumnList"] = new SelectList(lst, "Name", "Name");

                if (!IsEmpty(colSearch))
                    lst = lst.Where(col => col.Name.Contains(colSearch, StrComp)).ToList();

                ViewData["FiltrdColumnList"] = new SelectList(lst, "Name", "Name");
                var model = _mapper.Map<ServiceDetail>(service);
                model.Columns = lst;
                return View(model);
                //var model = new ServiceDetail()
                //{
                //    Name = service.Name,
                //    Endpoint = service.Endpoint,
                //    Enable = (bool)service.Enable,
                //    Columns = lst,
                //    QueryString = service.QueryString,
                //    Period = (TimeSpan)service.Period,
                //    Table = service.Table
                //};
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string Endpoint, ServiceDetail service)
        {
            if (service is null)
                return NotFound();
            if (!Endpoint.Equals(service.Endpoint))
                return NotFound();

            service.Name = service.Name?.Trim();
            service.Endpoint = service.Endpoint?.Trim();
            service.Table = service.Table?.Trim();
            service.QueryString = service.QueryString?.Trim().Replace("?", Emp);

            string qStr = service.QueryString;
            string fltr = "cross-company=true";
            try
            {
                service.QueryString += IsEmpty(qStr) ? fltr : qStr.Contains(fltr, StrComp) ? Emp : "&" + fltr;

                //if (ModelState.IsValid)
                //{
                //HashSet<ServiceDetail> set = (ConfigServices.ServiceSet) ?? throw new ArgumentNullException("Error: ConfigServices are null!");
                //ServiceDetail? existingService = set.FirstOrDefault(s => s.Endpoint == service.Endpoint);
                //if (existingService != null)
                //{
                try
                {
                    //set.Remove(existingService);
                    List<Column> cols = await GetColumns(null, service) ?? [];
                    //service.Columns ??= JsonConvert.SerializeObject(cols);

                    //bool success = set.Add(service);
                    //if (!success)
                    //    throw new Exception("Error: Passed Service could not be added to ServiceList!");

                    //set = [.. set.OrderBy(s => s.Name)];
                    //ConfigServices = new Services() { ServiceSet = set };

                    try
                    {
                        ServiceDto dto = _mapper.Map<ServiceDto>(service);
                        //PartialServiceDto dto = new()
                        //{
                        //    Endpoint = service.Endpoint,
                        //    Enable = service.Enable,
                        //    Name = service.Name,
                        //    Table = service.Table,
                        //    QueryString = service.QueryString,
                        //    Period = service.Period,
                        //    Columns = service.Columns.ToJson(),
                        //    TableAltered = service.TableAltere
                        //};
                        string json = Serialize.ToJson(dto);

                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = await Client.PutAsync($"{ApiBaseUrl}/{service.Endpoint}", content);
                        if (response == null)
                        {
                            Log("Falied to update service!");
                            //return Problem("ConfigServices could not be loaded!");
                            return View(service);
                        }
                        if (!response.IsSuccessStatusCode)
                        {
                            string msg = $"HTTP put request failed with status code: {response.StatusCode}";
                            Log(msg);
                            //return Problem("ConfigServices could not be loaded!");
                            return View(service);
                        }
                    }
                    catch (Exception)
                    { }
                }
                catch (Exception ex)
                {
                    LogInfo(ex, LogFile, NameSpacesUsed);
                    throw;
                }
                //}
                //}
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
        }

        [HttpGet]
        public IActionResult Reset()
        {
            try
            {
                var services = ReadConfig();
                AddedServices = null;
                ConfigServices = services;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
        }

        public async Task<IActionResult> SubmitNRestart()
        {
            try
            {
                await Submit();
                bool restartServices = false;

                for (int i = 0; i < 2; i++)
                {
                    restartServices = await ReBuild.RestartServices();
                    if (restartServices) break;
                }
                if (!restartServices) return Problem("Background ConfigServices could not be started");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
        }

        public async Task<IActionResult> Delete([FromQuery] string endPoint, [FromQuery] string name)
        {
            try
            {
                if (ConfigServices != null)
                {
                    ServiceDetail service = ConfigServices.ServiceSet.FirstOrDefault(s => s.Endpoint == endPoint);
                    if (service is not null)
                    {
                    ConfigServices?.ServiceSet?.Remove(service);
                    DeletedServices ??= [];
                    DeletedServices.Add(service);
                        //ViewData["ErrorMessage"] = $"Service '{name}' does not exist!";
                        //return RedirectToAction(nameof(Index));
                    }

                    using HttpResponseMessage response = await Client.DeleteAsync($"{ApiBaseUrl}/{endPoint}");

                    if (response == null)
                    {
                        Log("ConfigServices could not be loaded!");
                        //return Problem("ConfigServices could not be loaded!");
                        return View();
                    }
                    //response.EnsureSuccessStatusCode();
                    if (!response.IsSuccessStatusCode)
                    {
                        string msg = $"HTTP request failed with status code: {response.StatusCode}";
                        Log(msg);
                        //return Problem("ConfigServices could not be loaded!");
                        return View();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
        }

        public async Task<IActionResult> Submit(bool Redirect = true)
        {
            if (!(ConfigServices?.ServiceSet.Count > 0))
            {
                string msg = "Services are null or empty!";
                Log(msg);
                ViewData["ErrorMessage"] = msg;
                return RedirectToAction(nameof(Index));
            }
            try
            {
                ConfigServices.ServiceSet = [.. ConfigServices.ServiceSet.OrderBy(s => s.Endpoint)];
                string servicesJson = JsonConvert.SerializeObject(ConfigServices, Formatting.Indented);
                SysFile.WriteAllText(ConfigFullPath, servicesJson);
                ConfigServices = null;

                bool restartServices = false;

                for (int i = 0; i < 2; i++)
                {
                    //restartServices = await ReBuild.RestartServices(Client);
                    if (restartServices) break;
                }
                if (!restartServices)
                {
                    string msg = "Background Services could not be started!";
                    Log(msg);
                    ViewData["ErrorMessage"] = msg;
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
        }

        public async Task<IActionResult> Diagnostics(string? searchStr)
        {
            List<GetDiagnosResponseDto> result = [];
            try
            {
                using HttpResponseMessage response = await Client.GetAsync($"{ApiBaseUrl}/Diagnostics");
                if (response == null)
                {
                    Log("Services could not be loaded!");
                    //return Problem("Services could not be loaded!");
                    return View();
                }
                //response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                {
                    string msg = $"HTTP request failed with status code: {response.StatusCode}";
                    Log(msg);
                    //return Problem("Services could not be loaded!");
                    return View();
                }
                result = await response.Content.ReadFromJsonAsync<List<GetDiagnosResponseDto>>();
            }
            catch (Exception)
            { }

            if (ConfigServices is null)
            {
                Log("Services could not be loaded!");
                //return Problem("Services could not be loaded!");
                return View();
            }
            IEnumerable<GetDiagnosResponseDto> genreQry = from service in result orderby service.Name select service;

            if (genreQry is null || !genreQry.Any()) return View();

            List<GetDiagnosResponseDto> ServiceListOrgnl = genreQry.Distinct().ToList();

            if (!string.IsNullOrEmpty(searchStr))
                genreQry = genreQry.Where(s => s.Name!.Contains(searchStr));

            List<GetDiagnosResponseDto> ServiceListFltrd = genreQry.Distinct().ToList();
            ViewData["ServiceSet"] = new SelectList(ServiceListOrgnl, "Name", "Name");
            ViewData["ServiceListFltrd"] = new SelectList(ServiceListFltrd, "Name", "Name");

            List<List<GetDiagnosResponseDto>> lst = [ServiceListOrgnl, ServiceListFltrd];
            return View("Diagnostics", lst);
        }
    }

}