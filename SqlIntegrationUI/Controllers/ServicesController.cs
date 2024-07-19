using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace SqlIntegrationUI.Controllers
{
    public class ServicesController : Controller
    {
        private readonly string ConfigPathFull;
        private readonly IMemoryCache memoryCache;

        public Services? Services
        {
            get
            {
                try
                {
                    if (!memoryCache.TryGetValue("Services", out Services services))
                    {
                        services = ReadConfig();
                        var cacheEntryOpns = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60));
                        memoryCache.Set("Services", services, cacheEntryOpns);
                    }
                    return services;
                }
                catch (Exception Ex)
                {
                    throw;
                }
            }
            set
            {
                if (value == null)
                {
                    memoryCache.Remove("Services");
                }
                else if (value is Services)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60));
                    memoryCache.Set("Services", value, cacheEntryOptions);
                }
                else
                {
                    throw new Exception("The passed object is not of Services type!");
                }
            }
        }


        private Services ReadConfig()
        {
            try
            {
                string ConfigJson = System.IO.File.ReadAllText(ConfigPathFull);
                Services services = JsonConvert.DeserializeObject<Services>(ConfigJson);
                return services;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ServicesController(IMemoryCache memoryCache)
        {
            try
            {
                this.memoryCache = memoryCache;
                string solnPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
                string configName = "Config.json";
                ConfigPathFull = solnPath + "\\" + configName;
                if (Services is null) throw new Exception("Services not found");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Reset()
        {
            var services = ReadConfig();
            Services = services;
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Submit()
        {
            var services = Services;
            if (services == null)
            {
                return Problem("Services could not be loaded!");
            }
            try
            {
                string servicesJson = JsonConvert.SerializeObject(services, Formatting.Indented);
                System.IO.File.WriteAllText(ConfigPathFull, servicesJson);
                Services = null;
                bool restartServices = false;
                for (int i = 0; i < 2; i++)
                {
                    restartServices = await RestartServices();
                    if (restartServices) break;
                }
                if (!restartServices) return Problem("Background Services could not be started");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<bool> RestartServices()
        {
            string processName = "SqlIntegrationServices";
            string rlzStr = @"SqlIntegrationUI\\bin\\Release\\net8.0\\";
            string debugStr = @"SqlIntegrationUI\\bin\\Debug\\net8.0\\";
            string ProcessExecutable = @$"{Directory.GetParent(Directory.GetCurrentDirectory()).FullName.Replace(rlzStr, string.Empty).Replace(debugStr, string.Empty)}\SqlIntegrationServices\bin\Debug\net8.0\SqlIntegrationServices.exe";
            try
            {
                Process[] processes = Process.GetProcessesByName(processName);
                if (processes.Length != 0)
                {
                    foreach (var process in processes)
                    {
                        Console.WriteLine($"Killing process {process.ProcessName} (ID: {process.Id})...");
                        process.Kill();
                        await process.WaitForExitAsync(); // Ensure the process has fully exited
                        Console.WriteLine("Process killed successfully.");
                    }
                }
                else
                {
                    Console.WriteLine($"No running process named {processName} found.");
                }

                // Start the process again
                Console.WriteLine("Starting the process...");

                Console.WriteLine($"Attempting to start the process {ProcessExecutable} in a separate console window...");
                ProcessStartInfo startInfo = new()
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c start \"\" \"{ProcessExecutable}\"", // /c tells cmd to execute the command that follows and then exit
                    UseShellExecute = true,
                    CreateNoWindow = false
                };
                Process.Start(startInfo);

                Console.WriteLine("Process started successfully.");
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        public IActionResult Index(string searchString)
        {
            if (Services is null)
            {
                return Problem("Services could not be loaded!");
            }
            IEnumerable<ServiceDetail> genreQry = from serviceDtl in Services.ServiceList orderby serviceDtl.Name select serviceDtl;
            List<ServiceDetail> ServiceListOrgnl = genreQry.Distinct().ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                genreQry = genreQry.Where(s => s.Name!.Contains(searchString));
            }
            var ServiceListFltrd = genreQry.Distinct().ToList();
            ViewData["ServiceList"] = new SelectList(ServiceListOrgnl, "Name", "Name");
            ViewData["ServiceListFltrd"] = new SelectList(ServiceListFltrd, "Name", "Name");
            List<List<ServiceDetail>> lst = [ServiceListOrgnl, ServiceListFltrd];
            return View(lst);
        }

        // GET: ServicesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return NotFound();
            }
            ServiceDetail service = Services.ServiceList.Find(s => s.Name == name);
            if (service == null)
            {
                return NotFound();
            }
            service.Columns = service.Columns.OrderBy(c => c.Name).ToList();
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string name, ServiceDetail service)
        {
            if (!name.Equals(service.Name))
                return NotFound();
            if (ModelState.IsValid)
            {
                List<ServiceDetail> lst = Services.ServiceList;
                ServiceDetail? existingService = lst.FirstOrDefault(s => s.Endpoint == service.Endpoint);
                if (existingService != null)
                {
                    try
                    {
                        lst.Remove(existingService);
                        lst.Add(service);
                        lst = [.. lst.OrderBy(s => s.Name)];
                        Services = new Services() { ServiceList = lst };
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        //// POST: ServicesController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: ServicesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServicesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
