using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Diagnostics;
using SysFile = System.IO.File;
using Microsoft.CodeAnalysis;

namespace SqlIntegrationUI.Controllers
{
    public class ServicesController : Controller
    {
        private readonly string ConfigPathFull;
        private readonly IMemoryCache memoryCache;
        private readonly string Resource = "https://mfprod.operations.dynamics.com";
        private readonly string crntSolnDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

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
                    throw new Exception("The passed object is not of Service type!");
                }
            }
        }

        public Dictionary<string, JObject>? AddedServices
        {
            get
            {
                try
                {
                    if (!memoryCache.TryGetValue("AddedServices", out Dictionary<string, JObject> AddedServices))
                    {
                        var cacheEntryOpns = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60));
                        memoryCache.Set("AddedServices", AddedServices, cacheEntryOpns);
                    }
                    return AddedServices;
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
                else if (value is Dictionary<string, JObject>)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60));
                    memoryCache.Set("AddedServices", value, cacheEntryOptions);
                }
                else
                {
                    throw new Exception("The passed object is not of Service type!");
                }
            }
        }

        private Services ReadConfig()
        {
            try
            {
                string ConfigJson = SysFile.ReadAllText(ConfigPathFull);
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
                SysFile.WriteAllText(ConfigPathFull, servicesJson);
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
            string ProcessExecutable = @$"{crntSolnDirectory.Replace(rlzStr, string.Empty).Replace(debugStr, string.Empty)}\SqlIntegrationServices\bin\release\net8.0\SqlIntegrationServices.exe";
            try
            {
                Process[] processes = Process.GetProcessesByName(processName);
                if (processes.Length != 0)
                    foreach (var process in processes)
                    {
                        Console.WriteLine($"Killing process {process.ProcessName} (ID: {process.Id})...");
                        process.Kill(true);
                        await process.WaitForExitAsync(); // Ensure the process has fully exited
                        Console.WriteLine("Process killed successfully.");
                    }
                else
                    Console.WriteLine($"No running process named {processName} found.");


                bool buildSuccess = await GenerateModel();
                if (!buildSuccess)
                {
                    string projPath = $@"{crntSolnDirectory}\SqlIntegrationServices\SqlIntegrationServices.csproj";
                    if (!await RebuildSqlIntegrationServices(projPath))
                        Console.WriteLine("SqlIntegrationServices project could not be built!");
                }
                // Start the process again
                Console.WriteLine("Starting the process...");

                Console.WriteLine($"Attempting to start the process {ProcessExecutable} in a separate console window...");
                ProcessStartInfo startInfo = new()
                {
                    FileName = "cmd.exe",
                    /*Arguments = $"/c dotnet run --project \"{projPath}\"",*/
                    Arguments = $"/c start \"\" \"{ProcessExecutable}\"", // /c tells cmd to execute the command that follows and then exit
                    UseShellExecute = true,
                    CreateNoWindow = false
                };
                Process.Start(startInfo);
                await Task.Delay(2000);

                Console.WriteLine("Process started successfully.");
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private static async Task<bool> RebuildSqlIntegrationServices(string projPath)
        {
            string logFilePath = "build_log.txt";
            bool debugBuildSuccess = await BuildProject(projPath, "Debug", logFilePath);
            if (!debugBuildSuccess)
            {
                Console.WriteLine("Debug build failed. Check the log for details.");
            }

            bool rlzBuildSuccess = await BuildProject(projPath, "Release", logFilePath);
            if (!rlzBuildSuccess)
            {
                Console.WriteLine("Release build failed. Check the log for details.");
                return false;
            }
            return true;
        }

        private static async Task<bool> BuildProject(string projPath, string config, string logFilePath)
        {
            ProcessStartInfo proInfo = new()
            {
                FileName = "dotnet",
                Arguments = $"build \"{projPath}\" --configuration {config}",
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using Process process = Process.Start(proInfo);
            if (process is null)
            {
                Console.WriteLine("Failed to start build process.");
                return false;
            }

            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync();

            // Log output and errors
            SysFile.AppendAllText(logFilePath, $"{DateTime.Now} - {config} Build Output:\n{output}\n");
            if (!string.IsNullOrEmpty(error))
            {
                SysFile.AppendAllText(logFilePath, $"{DateTime.Now} - {config} Build Errors:\n{error}\n");
            }

            // Check if build was successful
            if (process.ExitCode != 0)
            {
                Console.WriteLine($"{config} build failed.");
                return false;
            }

            Console.WriteLine($"{config} build succeeded.");
            return true;
        }

        public IActionResult Index(string searchString)
        {
            if (Services is null)
            {
                return Problem("Services could not be loaded!");
            }
            IEnumerable<ServiceDetail> genreQry = from serviceDtl in Services.ServiceSet orderby serviceDtl.Name select serviceDtl;
            List<ServiceDetail> ServiceListOrgnl = genreQry.Distinct().ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                genreQry = genreQry.Where(s => s.Name!.Contains(searchString));
            }
            var ServiceListFltrd = genreQry.Distinct().ToList();
            ViewData["ServiceSet"] = new SelectList(ServiceListOrgnl, "Name", "Name");
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
        public async Task<IActionResult> Create(ServiceDetail service)
        {
            try
            {
                JObject jObj = await GetServiceJObject(service);
                AddedServices ??= [];
                AddedServices.TryAdd(service.Table, jObj);
                if (!Services.ServiceSet.Any(s => s.Name.Equals(service.Name, StringComparison.CurrentCultureIgnoreCase)))
                {
                    service.Columns = await GetColumns(jObj);
                    Services.ServiceSet.Add(service);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        // POST: ServicesController/AddFromExcel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFromExcel(ServiceDetail service)
        {
            try
            {
                if (!Services.ServiceSet.Any(s => s.Name.Equals(service.Name, StringComparison.CurrentCultureIgnoreCase)))
                {
                    JObject jObj = await GetServiceJObject(service);
                    service.Columns = await GetColumns(jObj);
                    Services.ServiceSet.Add(service);
                    AddedServices ??= [];
                    AddedServices.TryAdd(service.Table, jObj);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        private async Task<bool> GenerateModel()
        {
            //obtaining ConnectionString from user secret
            string connectionString = "Name=ConnectionStrings:DefaultConnection";
            string batchFilePath = "command.bat", logFilePath = "output.log";
            string tbls = Emp;
            bool genSuccess = true;
            if (AddedServices != null && AddedServices.Count > 0)
            {
                foreach (KeyValuePair<string, JObject> item in AddedServices)
                {
                    tbls += $"-t {item.Key.Trim().Replace("TEST", Emp, StringComparison.InvariantCultureIgnoreCase)} ";
                }
                if (IsEmpty(tbls)) return false;
                // Write commands to the batch file
                SysFile.WriteAllLines(batchFilePath,
                [
                    "@echo off",
                        $@"cd {crntSolnDirectory}\SqlIntegrationServices",
                        "echo Current Directory: %cd%",
                        $"dotnet ef dbcontext scaffold \"{connectionString}\" Microsoft.EntityFrameworkCore.SqlServer -o Models --no-pluralize   --context-namespace SqlIntegrationServices --no-onconfiguring --namespace SqlIntegrationServices --data-annotations {tbls} --no-build --force",
                        "echo Done" // Optional: indicate completion
                ]);

                // Set up the process start info to run the batch file
                ProcessStartInfo processInfo = new("cmd.exe", $"/c start cmd.exe /k \"{batchFilePath} > {logFilePath} 2>&1\"")
                {
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false, // This allows the cmd to open in a new window
                    CreateNoWindow = true
                };

                using Process process = Process.Start(processInfo);

                // Wait for the process to exit (optional)
                await process.WaitForExitAsync();
                await Task.Delay(3000);

                if (process.ExitCode != 0)
                {
                    genSuccess = false;
                    Problem("Error while genearting Models! \r\n Please see console for more details.");
                }
                try
                {
                    process.Kill(true);
                    await process.WaitForExitAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error killing process: {ex.Message}");
                    return false;
                }
                // Read and display the output from the log file
                string output = SysFile.ReadAllText(logFilePath);

                Console.WriteLine($"Output:\r\n{output}");
                // Clean up
                if (!SysFile.Exists(batchFilePath))
                    SysFile.Delete(batchFilePath);
                if (!SysFile.Exists(logFilePath))
                    SysFile.Delete(logFilePath);

                string projPath = $@"{crntSolnDirectory}\SqlIntegrationServices\SqlIntegrationServices.csproj";

                if (genSuccess && !await RebuildSqlIntegrationServices(projPath))
                {
                    Console.WriteLine("SqlIntegrationServices project could not be built!");
                    return false;
                }
                foreach (KeyValuePair<string, JObject> item in AddedServices)
                {
                    string entityName = $"{item.Key.Trim().Replace("TEST", Emp, StringComparison.InvariantCultureIgnoreCase)}";
                    if (UpdtModel(entityName, item.Value))
                        if (!await RebuildSqlIntegrationServices(projPath))
                        {
                            Console.WriteLine("SqlIntegrationServices project could not be re-built!");
                            return false;
                        }
                }
                return true;
            }
            return false;
        }

        private bool UpdtModel(string tableName, JObject jObj)
        {
            string nm = tableName.EndsWith("s", StringComparison.OrdinalIgnoreCase) ? "" : "";
            string projPath = @"C:\Users\rashmi.gupta\source\repos\WorkerServices\SqlIntegrationServices";
            string debugPath = @$"{projPath}\bin\Debug\net8.0\SqlIntegrationServices.dll";
            string rlzPath = @$"{projPath}\bin\Debug\net8.0\SqlIntegrationServices.dll";
            string filePath = $@"{projPath}\Models\{tableName}.cs";
            bool updated = false;

            Assembly asmbly = Assembly.LoadFrom(debugPath);
            asmbly ??= Assembly.LoadFrom(rlzPath);

            if (asmbly is null) return false;

            Type typ = asmbly.GetType($"SqlIntegrationServices.{tableName}Base");
            if (typ is null) return false;

            HashSet<string> classProps = typ.GetProperties(BindingFlags.Instance | BindingFlags.Public).Select(p => p.Name).ToHashSet();
            HashSet<string> jsonProps = jObj.Properties().Select(p => p.Name).ToHashSet();
            //var missingProps = jsonProps.Except(classProps);

            var missingProps = jsonProps
            .Select(prop => prop.Trim())
            .Except(classProps.Select(prop => prop.Trim()), StringComparer.OrdinalIgnoreCase)
            .ToList();

            string propStr = Emp;
            foreach (string item in missingProps)
            {
                if (item.Equals("@odata.etag", StringComparison.InvariantCultureIgnoreCase)) continue;
                JToken token = jObj[item];
                string propType = GetCSharpTypeFromJToken(token);
                propStr += $"\tpublic {propType} {item} {{ get; set; }}{Entr}";
            }
            if (!IsEmpty(propStr))
            {
                string classDef = $"{Entr}{Entr}public abstract partial class {tableName}Base{Entr}{{{Entr}{propStr}}}";

                SysFile.AppendAllText(filePath, classDef);
                return true;
            }
            return false;
        }

        private static string GetCSharpTypeFromJToken(JToken token)
        {
            return token.Type switch
            {
                JTokenType.Integer => "int",
                JTokenType.Float => "double",
                JTokenType.String => "string",
                JTokenType.Boolean => "bool",
                JTokenType.Date => "DateTime",
                JTokenType.Object => "object",
                JTokenType.Array => "List<object>", // Modify as needed
                _ => "string", // Default type
            };
        }

        private async Task<List<Column>> GetColumns(JObject jObj = null, ServiceDetail service = null)
        {
            List<Column> columns = null;
            try
            {
                if (jObj is null)
                    if (service is not null)
                        jObj = await GetServiceJObject(service);
                    else if (service is null)
                        ArgumentNullException.ThrowIfNull(service);

                columns = jObj.Properties().Select(p => new Column() { Name = p.Name, Include = true }).ToList();
                columns.ForEach(col => { if (col.Name == "@odata.etag") { col.Name = "Etag"; } });
                return columns;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<JObject> GetServiceJObject(ServiceDetail service)
        {
            JObject obj2 = null;
            string url = $"{Resource}/data/{service.Endpoint}?top=1";
            string result = Emp;
            for (int cnt = 1; cnt <= 2; cnt++)
            {
                result = await GetJson(Resource, url);
                if (!IsEmpty(result))
                    break;
            }

            JObject obj = JObject.Parse(result);
            JArray Items = (JArray)obj["value"];

            for (int cnt = 1; cnt <= 2; cnt++)
            {
                try
                {
                    obj2 = Items[0] as JObject;
                    break;
                }
                catch (Exception ex)
                {
                    if (cnt == 2)
                        throw;
                }
            }
            return obj2;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string name, string colSearch)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return NotFound();
            }
            ServiceDetail service = Services.ServiceSet.First(s => s.Name == name);
            if (service == null)
            {
                return NotFound();
            }
            List<Column> lst = service.Columns;
            lst ??= await GetColumns(null, service);
            lst = lst?.OrderBy(c => c?.Name)?.ToList();

            ViewData["ColumnList"] = new SelectList(lst, "Name", "Name");

            if (!IsEmpty(colSearch))
                lst = lst.Where(col => col.Name.Contains(colSearch, StringComparison.InvariantCultureIgnoreCase)).ToList();

            ViewData["FiltrdColumnList"] = new SelectList(lst, "Name", "Name");

            //service.Columns = [.. service?.Columns?.OrderBy(c => c.Name)];
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string name, ServiceDetail service)
        {
            if (!name.Equals(service?.Name))
                return NotFound();
            if (service is null)
                return NotFound();

            //if (ModelState.IsValid)
            //{
            HashSet<ServiceDetail> set = (Services?.ServiceSet) ?? throw new ArgumentNullException("Error: Services are null!");
            ServiceDetail? existingService = set.FirstOrDefault(s => s.Endpoint == service.Endpoint);
            if (existingService != null)
            {
                try
                {
                    set.Remove(existingService);
                    bool success = set.Add(service);
                    if (!success)
                    {
                        throw new Exception("Error: Passed Service could not be added to ServiceList!");
                    }
                    set = [.. set.OrderBy(s => s.Name)];
                    Services = new Services() { ServiceSet = set };
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            //}
            return RedirectToAction(nameof(Index));
        }

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

//            foreach (JProperty prop in props)
//            {
//                commonCode += "";
//            }

//string baseClassName = $"{service.Name}Base";
//string baseClassCode = $"\r\n public class {baseClassName}\r\n {{\r\n{commonCode}\r\n}}";
//string testClassCode = $"\r\n public class {service.Name}Test: {baseClassName} {{}}";
//string orgnlClassCode = $"\r\n public class {service.Name}: {baseClassName} {{}}";
//string fullModelCode = $"{baseClassCode}{testClassCode}{orgnlClassCode}";