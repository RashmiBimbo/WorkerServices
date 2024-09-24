using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using SysFile = System.IO.File;
using Microsoft.CodeAnalysis;
using CommonCode.Models.Dtos.Requests;
using CommonCode.Models.Dtos.Responses;
using static System.Net.WebRequestMethods;
using CommonCode.Models.Dtos;
using CommonCode.CommonClasses;
using static CommonCode.CommonClasses.Common;

namespace SqlIntegrationUI.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IHttpClientFactory HttpClientFactory;
        private readonly HttpClient Client;

        public ServicesController(IHttpClientFactory httpClientFactory)
        {
            ArgumentNullException.ThrowIfNull(httpClientFactory);
            try
            {
                HttpClientFactory = httpClientFactory;
                Client = HttpClientFactory.CreateClient();

                if (ConfigServices is null)
                {
                    Log("ConfigServices not found");
                    ConfigServices = new Services { ServiceSet = [] };

                    //throw new Exception("ConfigServices not found")};
                }
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
                try
                {
                    var response = await Client.GetAsync($"{BaseUrl}/Services");
                    if (response == null)
                    {
                        Log("ConfigServices could not be loaded!");
                        //return Problem("ConfigServices could not be loaded!");
                        return View();
                    }
                    response.EnsureSuccessStatusCode();
                    if (!response.IsSuccessStatusCode)
                    {
                        string msg = $"HTTP request failed with status code: {response.StatusCode}";
                        Log(msg);
                        //return Problem("ConfigServices could not be loaded!");
                        return View();
                    }
                    var result = await response.Content.ReadFromJsonAsync<GetServiceResponseDto[]>();
                }
                catch (Exception)
                { }
                if (ConfigServices is null)
                {
                    Log("ConfigServices could not be loaded!");
                    //return Problem("ConfigServices could not be loaded!");
                    return View();
                }
                IEnumerable<ServiceDetail> genreQry = from serviceDtl in ConfigServices.ServiceSet orderby serviceDtl.Name select serviceDtl;

                if (genreQry is null || genreQry.Count() < 1) return View();

                List<ServiceDetail> ServiceListOrgnl = genreQry.Distinct().ToList();

                if (!string.IsNullOrEmpty(searchString))
                    genreQry = genreQry.Where(s => s.Name!.Contains(searchString));

                var ServiceListFltrd = genreQry.Distinct().ToList();
                ViewData["ServiceSet"] = new SelectList(ServiceListOrgnl, "Name", "Name");
                ViewData["ServiceListFltrd"] = new SelectList(ServiceListFltrd, "Name", "Name");

                List<List<ServiceDetail>> lst = [ServiceListOrgnl, ServiceListFltrd];
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
            if (IsEmpty(Endpoint))
                return NotFound();
            try
            {
                ServiceDetail service = ConfigServices.ServiceSet.First(s => s.Endpoint == Endpoint);

                if (service == null)
                    return NotFound();

                List<Column> lst;
                if (service.Columns is null)
                {
                    ConfigServices.ServiceSet.Remove(service);
                    lst = await GetColumns(null, service) ?? [];
                    service.Columns ??= lst;
                    ConfigServices.ServiceSet.Add(service);
                }
                else
                    lst = service.Columns;

                lst = lst.OrderBy(c => c?.Name)?.ToList();

                ViewData["ColumnList"] = new SelectList(lst, "Name", "Name");

                if (!IsEmpty(colSearch))
                    lst = lst.Where(col => col.Name.Contains(colSearch, StrComp)).ToList();

                ViewData["FiltrdColumnList"] = new SelectList(lst, "Name", "Name");

                return View(service);
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
                HashSet<ServiceDetail> set = (ConfigServices.ServiceSet) ?? throw new ArgumentNullException("Error: ConfigServices are null!");
                ServiceDetail? existingService = set.FirstOrDefault(s => s.Endpoint == service.Endpoint);
                if (existingService != null)
                {
                    try
                    {
                        set.Remove(existingService);
                        service.Columns ??= await GetColumns(null, service) ?? [];

                        bool success = set.Add(service);
                        if (!success)
                            throw new Exception("Error: Passed Service could not be added to ServiceList!");

                        set = [.. set.OrderBy(s => s.Name)];
                        ConfigServices = new Services() { ServiceSet = set };

                        try
                        {
                            var response = await Client.GetAsync($"{BaseUrl}/Services/{service.Endpoint}");
                            if (response == null)
                            {
                                Log("ConfigServices could not be loaded!");
                                //return Problem("ConfigServices could not be loaded!");
                                return View();
                            }
                            response.EnsureSuccessStatusCode();
                            if (!response.IsSuccessStatusCode)
                            {
                                string msg = $"HTTP request failed with status code: {response.StatusCode}";
                                Log(msg);
                                //return Problem("ConfigServices could not be loaded!");
                                return View();
                            }
                            var result = await response.Content.ReadFromJsonAsync<GetServiceResponseDto[]>();
                        }
                        catch (Exception)
                        { }
                    }
                    catch (Exception ex)
                    {
                        LogInfo(ex, LogFile, NameSpacesUsed);
                        throw;
                    }
                }
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
                    if (service is null)
                    {
                        ViewData["ErrorMessage"] = $"Service '{name}' does not exist!";
                        return RedirectToAction(nameof(Index));
                    }
                    ConfigServices?.ServiceSet?.Remove(service);
                    DeletedServices ??= [];
                    DeletedServices.Add(service);
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
                    restartServices = await ReBuild.RestartServices(Client);
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
    }
}