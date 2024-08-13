using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Diagnostics;
using SysFile = System.IO.File;
using Microsoft.CodeAnalysis;
using static System.Net.Mime.MediaTypeNames;

namespace SqlIntegrationUI.Controllers
{
    public class ServicesController : Controller
    {
        private readonly string ConfigFullPath;
        private readonly IMemoryCache memoryCache;
        private readonly string Resource = "https://mfprod.operations.dynamics.com";
        private readonly string CrntSolnDirectory;
        string SqlIntegrationServicesProject;
        string SqlIntegrationServicesPath;

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

        public ServicesController(IMemoryCache memoryCache)
        {
            try
            {
                this.memoryCache = memoryCache;
                CrntSolnDirectory = GetSolnFolder();
                ConfigFullPath = GetConfigFullPath();
                SqlIntegrationServicesProject = Path.Combine(CrntSolnDirectory, "SqlIntegrationServices\\SqlIntegrationServices.csproj");
                SqlIntegrationServicesPath = Path.Combine(CrntSolnDirectory, "SqlIntegrationServices");
                if (Services is null) throw new Exception("Services not found");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private Services ReadConfig()
        {
            try
            {
                string ConfigJson = SysFile.ReadAllText(ConfigFullPath);
                Services services = JsonConvert.DeserializeObject<Services>(ConfigJson);
                return services;
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
            AddedServices = null;
            Services = services;
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SubmitNRestart()
        {
            try
            {
                await Submit();
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

        public async Task<IActionResult> Submit(bool Redirect = true)
        {
            var services = Services;
            if (services == null)
            {
                return Problem("Services could not be loaded!");
            }
            try
            {
                string servicesJson = JsonConvert.SerializeObject(services, Formatting.Indented);
                SysFile.WriteAllText(ConfigFullPath, servicesJson);
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
            string ProcessExecutable = @$"{CrntSolnDirectory.Replace(rlzStr, string.Empty).Replace(debugStr, string.Empty)}\SqlIntegrationServices\bin\release\net8.0\SqlIntegrationServices.exe";
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
                    if (!await RebuildSqlIntegrationServices(SqlIntegrationServicesProject))
                        Console.WriteLine("SqlIntegrationServices project could not be built!");
                }
                // Start the process again
                Console.WriteLine("Starting the process...");

                Console.WriteLine($"Attempting to start the process {ProcessExecutable} in a separate console window...");
                ProcessStartInfo startInfo = new()
                {
                    FileName = "cmd.exe",
                    /*Arguments = $"/c dotnet run --project \"{SqlIntegrationServicesProject}\"",*/
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
            ProcessStartInfo cleanInfo = new()
            {
                FileName = "dotnet",
                Arguments = $"clean \"{projPath}\" --configuration {config}",
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using Process cleanProcess = Process.Start(cleanInfo);
            cleanProcess.WaitForExitAsync();

            string output = await cleanProcess.StandardOutput.ReadToEndAsync();
            string error = await cleanProcess.StandardError.ReadToEndAsync();
            // Log output and errors
            SysFile.AppendAllText(logFilePath, $"{DateTime.Now} - {config} Clean Output:\n{output}\n");

            if (!string.IsNullOrEmpty(error))
            {
                SysFile.AppendAllText(logFilePath, $"{DateTime.Now} - {config} Build Errors:\n{error}\n");
            }

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
            await Task.Delay(2000);
            using Process process = Process.Start(proInfo);
            if (process is null)
            {
                Console.WriteLine("Failed to start build process.");
                return false;
            }

            output = await process.StandardOutput.ReadToEndAsync();
            error = await process.StandardError.ReadToEndAsync();
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
                SysFile.AppendAllText(logFilePath, $"{DateTime.Now} - {config} Build Output:\n{error}\n");
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
            return View("Create");
        }


        // POST: ServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceDetail service)
        {
            if (service is null)
                Problem("Error creating Service! \r\n Service is null.");

            try
            {
                service.Name = service.Name?.Trim();
                service.Endpoint = service.Endpoint?.Trim();
                service.Table = service.Table?.Trim();
                service.QueryString = service.QueryString?.Trim();

                string qStr = service.QueryString;
                string fltr = "cross-company=true";
                service.QueryString += IsEmpty(qStr) ? fltr : qStr.Contains(fltr, StrComp) ? Emp : "&" + fltr;
                JObject jObj = await GetServiceJObject(service);
                AddedServices ??= [];
                AddedServices.TryAdd(service.Table, jObj);
                if (!Services.ServiceSet.Any(s => s.Name.Equals(service.Name, StrComp)))
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
                if (!Services.ServiceSet.Any(s => s.Name.Equals(service.Name, StrComp)))
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
            string tbls = Emp;
            bool genSuccess = true;
            List<Type> types = GetTypes();

            foreach (ServiceDetail service in Services.ServiceSet)
            {
                string tblName = service.Table.Trim();
                Type typ = Type.GetType($"SqlIntegrationServices.{tblName}, SqlIntegrationServices", throwOnError: false, ignoreCase: true);
                if (!types.Contains(typ))
                {
                    JObject jObj = await GetServiceJObject(service);
                    AddedServices ??= [];
                    AddedServices.TryAdd(tblName, jObj);
                }
            }

            if (AddedServices != null && AddedServices.Count > 0)
                foreach (KeyValuePair<string, JObject> item in AddedServices)
                {
                    string tblName = item.Key.Trim();
                    tblName = tblName.EndsWith("TEST", StrComp) ? tblName.Remove(tblName.LastIndexOf("Test"), 4) : tblName;
                    tbls += $"-t {tblName} ";
                }

            if (IsEmpty(tbls)) return false;

            genSuccess = await GenerateModel(tbls);

            if (genSuccess && !await RebuildSqlIntegrationServices(SqlIntegrationServicesProject))
            {
                Console.WriteLine("SqlIntegrationServices project could not be built!");
                return false;
            }
            foreach (KeyValuePair<string, JObject> item in AddedServices)
            {
                string entityName = item.Key.Trim();
                entityName = entityName.EndsWith("TEST", StrComp) ? entityName.Remove(entityName.LastIndexOf("Test"), 4) : entityName;
                string filePath = $@"{SqlIntegrationServicesPath}\Models\{entityName}.cs";
                bool updated = false;

                Type typ = Type.GetType($"SqlIntegrationServices.{entityName}, SqlIntegrationServices", throwOnError: false, ignoreCase: true);
                if ((typ is null) || !types.Contains(typ))
                {
                    Console.WriteLine($"Given type {entityName} does not exist!");
                    return false;
                }
                bool updtModel = UpdtModel(entityName, item.Value, filePath, typ);
                if (updtModel)
                {
                    if (!await RebuildSqlIntegrationServices(SqlIntegrationServicesProject))
                    {
                        Console.WriteLine("SqlIntegrationServices project could not be re-built!");
                        return false;
                    }
                    Services.ServiceSet.First(s => s.Table.Equals(item.Key, StrComp)).Altered = true;
                }
            }
            return true;
        }

        private async Task<bool> GenerateModel(string tbls)
        {
            string batchFilePath = "command.bat", logFilePath = "output.log";
            bool genSuccess = true;

            SysFile.WriteAllLines(batchFilePath,
            [
                "@echo off",
                 $@"cd {CrntSolnDirectory}\SqlIntegrationServices",
                 "echo Current Directory: %cd%",
                 $"dotnet ef dbcontext scaffold \"Data Source=10.10.1.138;Initial Catalog=MFELDynamics365;User ID=sa;Password='=*fj9*N*uLBRNZV';Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False\" Microsoft.EntityFrameworkCore.SqlServer -o Models --no-pluralize " +
                 $"--use-database-names --context-namespace SqlIntegrationServices --namespace SqlIntegrationServices " +
                 $"--data-annotations {tbls} --no-build --force",
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

            return genSuccess;
        }

        private bool UpdtModel(string tableName, JObject jObj, string filePath, Type typ)
        {
            if (typ is null) return false;
            if (jObj is null) return false;

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
                if (item.Equals("@odata.etag", StrComp)) continue;

                JToken token = jObj[item];
                string propType = GetCSharpTypeFromJToken(token);
                propStr += $"\tpublic {propType} {item} {{ get; set; }}{Entr}";
            }
            if (!IsEmpty(propStr))
            {
                string classDef = $"{Entr}public abstract partial class {tableName}Base{Entr}{{{Entr}{propStr}}}";

                SysFile.AppendAllText(filePath, classDef);
                return true;
            }
            return false;
        }

        private List<Type> GetTypes()
        {
            string debugPath = @$"{SqlIntegrationServicesPath}\bin\Debug\net8.0\SqlIntegrationServices.dll";
            string rlzPath = @$"{SqlIntegrationServicesPath}\bin\Debug\net8.0\SqlIntegrationServices.dll";

            Assembly asmbly = Assembly.LoadFrom(rlzPath);
            asmbly ??= Assembly.LoadFrom(debugPath);

            if (asmbly is null) return null;

            Type[] typs = asmbly.GetTypes();
            return [.. typs];
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
                JTokenType.TimeSpan => "TimeSpan",
                JTokenType.Guid => "Guid",
                JTokenType.Uri => "Uri",
                JTokenType.Object => "object",
                JTokenType.Array => "List<object>",
                JTokenType.Null => "object",
                JTokenType.Undefined => "object",
                JTokenType.Bytes => "byte[]",
                JTokenType.Property => "object",
                JTokenType.Comment => "string",
                JTokenType.Raw => "string",
                _ => "object",
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
                    else
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
            JObject jObjRslt = null;
            string and = IsEmpty(service.QueryString) ? Emp : "&";
            string url = $"{Resource}/data/{service.Endpoint}?{service.QueryString}{and}$top=1";
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
                    jObjRslt = Items[0] as JObject;
                    break;
                }
                catch (Exception ex)
                {
                    if (cnt == 2)
                        throw;
                }
            }
            return jObjRslt;
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
                return NotFound();

            List<Column> lst;
            if (service.Columns is null)
            {
                Services.ServiceSet.Remove(service);
                lst = await GetColumns(null, service) ?? [];
                service.Columns ??= lst;
                Services.ServiceSet.Add(service);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string name, ServiceDetail service)
        {
            if (service is null)
                return NotFound();
            if (!name.Equals(service.Name))
                return NotFound();

            service.Name = service.Name?.Trim();
            service.Endpoint = service.Endpoint?.Trim();
            service.Table = service.Table?.Trim();
            service.QueryString = service.QueryString?.Trim().Replace("?", Emp);

            string qStr = service.QueryString;
            string fltr = "cross-company=true";
            service.QueryString += IsEmpty(qStr) ? fltr : qStr.Contains(fltr, StrComp) ? Emp : "&" + fltr;


            //if (ModelState.IsValid)
            //{
            HashSet<ServiceDetail> set = (Services.ServiceSet) ?? throw new ArgumentNullException("Error: Services are null!");
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