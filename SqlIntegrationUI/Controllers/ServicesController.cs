using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Diagnostics;
using SysFile = System.IO.File;
using Microsoft.CodeAnalysis;
using static SqlIntegrationUI.UIUtilities.UICommonCode;


namespace SqlIntegrationUI.Controllers
{
    public class ServicesController : Controller
    {
        public ServicesController(IMemoryCache memoryCache)
        {
            try
            {
                if (ConfigServices is null)
                {
                    Console.WriteLine("ConfigServices not found");
                    ConfigServices = new Services
                    {
                        ServiceSet = []
                    };
                    //throw new Exception("ConfigServices not found")};
                }
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                if (ConfigServices is null)
                {
                    Console.WriteLine("ConfigServices could not be loaded!");
                    //return Problem("ConfigServices could not be loaded!");
                    return View();
                }
                IEnumerable<ServiceDetail> genreQry = from serviceDtl in ConfigServices.ServiceSet orderby serviceDtl.Name select serviceDtl;
                if (genreQry is null || genreQry.Count() < 1) return View();
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
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string name, string colSearch)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return NotFound();
            }

            try
            {
                ServiceDetail service = ConfigServices.ServiceSet.First(s => s.Name == name);

                if (service == null)
                    return NotFound();

                List<Column> lst;
                if (service.Columns is null)
                {
                    UIUtilities.UICommonCode.ConfigServices.ServiceSet.Remove(service);
                    lst = await GetColumns(null, service) ?? [];
                    service.Columns ??= lst;
                    UIUtilities.UICommonCode.ConfigServices.ServiceSet.Add(service);
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
                        UIUtilities.UICommonCode.ConfigServices = new Services() { ServiceSet = set };
                    }
                    catch (Exception ex)
                    {
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
                    restartServices = await RestartServices();
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

        public async Task<IActionResult> Submit(bool Redirect = true)
        {
            var services = UIUtilities.UICommonCode.ConfigServices;
            if (services == null)
            {
                return Problem("ConfigServices could not be loaded!");
            }
            try
            {
                string servicesJson = JsonConvert.SerializeObject(services, Formatting.Indented);
                SysFile.WriteAllText(ConfigFullPath, servicesJson);
                UIUtilities.UICommonCode.ConfigServices = null;
                bool restartServices = false;

                for (int i = 0; i < 2; i++)
                {
                    restartServices = await RestartServices();
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

        private async Task<bool> RestartServices()
        {
            string processName = $"{CrntProjName}";
            string rlzStr = @$"{CrntProjName}\\bin\\Release\\net8.0\\";
            string debugStr = @$"{CrntProjName}\\bin\\Debug\\net8.0\\";
            string ProcessExecutable = @$"{CrntSolnFolder.Replace(rlzStr, string.Empty).Replace(debugStr, string.Empty)}\{CrntProjName}\bin\release\net8.0\{CrntProjName}.exe";
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
                    if (!await RebuildSqlIntegrationServices(CrntProjPathFullPath))
                        Console.WriteLine($"{CrntProjName} project could not be built!");
                }
                // Start the process again
                Console.WriteLine("Starting the process...");

                Console.WriteLine($"Attempting to start the process {ProcessExecutable} in a separate console window...");
                ProcessStartInfo startInfo = new()
                {
                    FileName = "cmd.exe",
                    /*Arguments = $"/c dotnet run --project \"{CrntProjPathFullPath}\"",*/
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
                LogInfo(ex, LogFile, NameSpacesUsed);
                return false;
            }
            return true;
        }

        private async Task<bool> RebuildSqlIntegrationServices(string projPath)
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

        private async Task<bool> BuildProject(string projPath, string config, string logFilePath)
        {
            try
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
                //bool suceess = await TryInDfrntWindow(config);
                ProcessStartInfo proInfo = new()
                {
                    FileName = "dotnet",
                    Arguments = $"build \"{projPath}\" --configuration {config}",
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false, // This allows the cmd to open in a new window
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
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                return false;
            }
        }

        private async Task<bool> TryInDfrntWindow(string config)
        {
            try
            {
                string batchFilePath = "buildcommand.bat", logFile = "buildoutput.log";
                bool genSuccess = true;

                SysFile.WriteAllLines(batchFilePath,
                [
                    "@echo off",
                 $@"cd {CrntProjFolder}",
                 "echo Current Directory: %cd%",
                 $"dotnet build \"{CrntProjPathFullPath}\" --configuration {config}",
                 "echo Done" // Optional: indicate completion
                ]);
                // Set up the process start info to run the batch file
                ProcessStartInfo processInfo = new("cmd.exe", $"/c start cmd.exe /k \"{batchFilePath} > {logFile} 2>&1\"")
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
                    Console.WriteLine("Error while genearting Models! \r\n Please see console for more details.");
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
                string output = SysFile.ReadAllText(logFile);

                Console.WriteLine($"Output:\r\n{output}");
                // Clean up
                if (!SysFile.Exists(batchFilePath))
                    SysFile.Delete(batchFilePath);
                if (!SysFile.Exists(logFile))
                    SysFile.Delete(logFile);

                return genSuccess;
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                return false;
            }
        }

        private async Task<bool> GenerateModel()
        {
            //obtaining MFELConnStr from user secret
            string tbls = Emp;
            bool genSuccess = true;
            List<Type> types = GetTypes();
            try
            {

                foreach (ServiceDetail service in ConfigServices.ServiceSet)
                {
                    string tblName = service.Table.Trim();
                    Type typ = Type.GetType($"{CrntProjName}.{tblName}, {CrntProjName}", throwOnError: false, ignoreCase: true);
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

                if (genSuccess && !await RebuildSqlIntegrationServices(CrntProjPathFullPath))
                {
                    Console.WriteLine($"{CrntProjName} project could not be built!");
                    return false;
                }
                if (AddedServices is null)
                {
                    Console.WriteLine("Added ConfigServices are null. No update in model is performed for them");
                    return true;
                }
                foreach (KeyValuePair<string, JObject> item in AddedServices)
                {
                    string entityName = item.Key.Trim();
                    entityName = entityName.EndsWith("TEST", StrComp) ? entityName.Remove(entityName.LastIndexOf("Test"), 4) : entityName;
                    string filePath = $@"{CrntProjFolder}\Models\{entityName}.cs";
                    bool updated = false;

                    Type typ = Type.GetType($"{CrntProjName}.{entityName}, {CrntProjName}", throwOnError: false, ignoreCase: true);
                    if ((typ is null) || !types.Contains(typ))
                    {
                        Console.WriteLine($"Given type {entityName} does not exist!");
                        return false;
                    }
                    bool updtModel = UpdtModel(entityName, item.Value, filePath, typ);
                    if (updtModel)
                    {
                        if (!await RebuildSqlIntegrationServices(CrntProjPathFullPath))
                        {
                            Console.WriteLine($"{CrntProjName} project could not be re-built!");
                            return false;
                        }
                        ConfigServices.ServiceSet.First(s => s.Table.Equals(item.Key, StrComp)).Altered = true;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                return false;
            }
        }

        private async Task<bool> GenerateModel(string tbls)
        {
            try
            {
                string batchFilePath = "command.bat", logFilePath = "output.log";
                bool genSuccess = true;

                SysFile.WriteAllLines(batchFilePath,
                [
                    "@echo off",
                 $@"cd {CrntSolnFolder}\{CrntProjName}",
                 "echo Current Directory: %cd%",
                 $"dotnet ef dbcontext scaffold \"{MFELConnStr}\" Microsoft.EntityFrameworkCore.SqlServer -o Models --no-pluralize " +
                 $"--use-database-names --context-namespace {CrntProjName} --namespace {CrntProjName} " +
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
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                return false;
            }
        }

        private bool UpdtModel(string tableName, JObject jObj, string filePath, Type typ)
        {
            if (typ is null) return false;
            if (jObj is null) return false;

            try
            {
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
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                return false;
            }
        }

        private List<Type> GetTypes()
        {
            try
            {
                string debugPath = @$"{CrntProjFolder}\bin\Debug\net8.0\{CrntProjName}.dll";
                string rlzPath = @$"{CrntProjFolder}\bin\Debug\net8.0\{CrntProjName}.dll";

                Assembly asmbly = Assembly.LoadFrom(rlzPath);
                asmbly ??= Assembly.LoadFrom(debugPath);

                if (asmbly is null) return null;

                Type[] typs = asmbly.GetTypes();
                return [.. typs];
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                throw;
            }
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

    }
}