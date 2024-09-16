using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Reflection;
using static System.DateTime;

namespace SqlIntegrationUI.UIUtilities
{
    public static class ReBuild
    {
        private static readonly string ServiceProjFoldr, ServiceProjFullPath;
        private static readonly string DebugFolder, RlzFolder;

        static ReBuild()
        {
            ServiceProjFoldr = Comb(CrntSolnFolder, SqlIntegrationServices);
            ServiceProjFullPath = Comb(ServiceProjFoldr, $"{SqlIntegrationServices}.csproj");

            DebugFolder = @$"{ServiceProjFoldr}\bin\Debug\net8.0\";
            RlzFolder = @$"{ServiceProjFoldr}\bin\Release\net8.0\";
        }

        public static async Task<bool> RestartServices()
        {
            string ProcessExecutable = Comb(RlzFolder, $"{SqlIntegrationServices}.exe");
            try
            {
                Process[] processes = Process.GetProcessesByName(SqlIntegrationServices);
                if (processes.Length != 0)
                    foreach (var process in processes)
                    {
                        Log($"Killing process {process.ProcessName} (ID: {process.Id})...");
                        process.Kill(true);
                        await process.WaitForExitAsync(); // Ensure the process has fully exited
                        Log("Process killed successfully.");
                    }
                else
                    Log($"No running process named {SqlIntegrationServices} found.");

                await DeleteServices();

                //bool buildSuccess = await GenerateModel();
                await UpdateModels();

                //if (!buildSuccess)
                //{
                //    Log($"{SqlIntegrationServices} project could not be built after adding services!");

                //    if (!await RebuildSqlIntegrationServices(ServiceProjFullPath))
                //        Log($"{SqlIntegrationServices} project could not be re-built !");
                //}
                // Start the process again
                Log($"Starting the process {SqlIntegrationServices}...");

                Log($"Attempting to start the process {ProcessExecutable} in a separate console window...");
                ProcessStartInfo startInfo = new()
                {
                    FileName = "cmd.exe",
                    /*Arguments = $"/c dotnet run --project \"{ServiceProjFullPath}\"",*/
                    Arguments = $"/c start \"\" \"{ProcessExecutable}\"", // /c tells cmd to execute the command that follows and then exit
                    UseShellExecute = true,
                    CreateNoWindow = false
                };
                Process.Start(startInfo);
                await Task.Delay(2000);

                Log("Process started successfully.");
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                return false;
            }
            return true;
        }

        private static async Task<bool> UpdateModels()
        {
            List<Type> types = GetTypes();
            foreach (ServiceDetail item in ConfigServices.ServiceSet)
            {
                JObject? itmJObj = null;
                string entityName = item.Table;
                entityName = entityName.EndsWith("TEST", StrComp) ? entityName.Remove(entityName.LastIndexOf("Test"), 4) : entityName;

                string filePath = $@"{SqlIntegrationServices}\Models\{entityName}.cs";
                bool updated = false;

                Type typ = Type.GetType($"{SqlIntegrationServices}.{entityName}, {SqlIntegrationServices}", throwOnError: false, ignoreCase: true);
                if ((typ is null) || !types.Contains(typ))
                {
                    Log($"Given type {entityName} does not exist!");
                    return false;
                }
                if (AddedServices != null && AddedServices.ContainsKey(item.Table))
                    AddedServices.TryGetValue(item.Table, out itmJObj);

                bool updtModel = UpdtModel(entityName, itmJObj, filePath, typ);
                if (updtModel)
                {
                    if (!await RebuildSqlIntegrationServices(ServiceProjFullPath))
                    {
                        Log($"{SqlIntegrationServices} project could not be re-built!");
                        return false;
                    }
                    ConfigServices.ServiceSet.First(s => s.Table.Equals(item.Table, StrComp)).TableAltered = true;
                }
            }
            return true;
        }

        public static async Task<bool> RebuildSqlIntegrationServices(string projPath)
        {
            string logFilePath = Comb(CrntProjLogFolder, "build_log.txt");
            await CleanProject(projPath, "Debug", logFilePath);

            bool debugBuildSuccess = await BuildProject(projPath, "Debug", logFilePath);
            if (!debugBuildSuccess)
            {
                Log("Debug build failed. Check the log for details.");
            }

            await CleanProject(projPath, "Release", logFilePath);

            bool rlzBuildSuccess = await BuildProject(projPath, "Release", logFilePath);
            if (!rlzBuildSuccess)
            {
                Log("Release build failed. Check the log for details.");
                return false;
            }
            return true;
        }

        public static async Task<bool> BuildProject(string projPath, string config, string logFilePath)
        {
            try
            {
                string output, error;
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
                    Log($"Failed to start build process.");
                    return false;
                }

                output = await process.StandardOutput.ReadToEndAsync();
                error = await process.StandardError.ReadToEndAsync();
                await process.WaitForExitAsync();

                // Log output and errors
                File.AppendAllText(logFilePath, $"{config} Build Output:{output}");
                if (!IsEmpty(error))
                    File.AppendAllText(logFilePath, $"{config} Build Errors:{error}");

                // Check if build was successful
                if (process.ExitCode != 0)
                {
                    string msg = $"{config} build failed. Build Output:{error}";
                    File.AppendAllText(logFilePath, msg);
                    Log(msg);
                    return false;
                }

                Log($"{config} build succeeded.");
                return true;
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed, $"{Now}: Error while building {SqlIntegrationServices} project in {config} configuration:");
                return false;
            }
        }

        public static async Task CleanProject(string projPath, string config, string logFilePath)
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
                Process cleanProcess = Process.Start(cleanInfo);
                cleanProcess.WaitForExitAsync();

                if (cleanProcess.ExitCode != 0)
                    Log($"Error while cleaning {SqlIntegrationServices}");

                string output = await cleanProcess.StandardOutput.ReadToEndAsync();
                string error = await cleanProcess.StandardError.ReadToEndAsync();

                if (!IsEmpty(output))
                {
                    string msg = $"{config} Clean Output:{output}";
                    //File.AppendAllText(logFilePath, msg);
                    Log(msg, true, logFilePath);
                }

                if (!IsEmpty(error))
                {
                    string errMsg = $"{config} Clean Errors:{error}";
                    //File.AppendAllText(logFilePath, errMsg);
                    Log(errMsg, true, logFilePath);
                }
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed, $"{Now}: Error while cleaning {SqlIntegrationServices} project in {config} configuration:");
            }
        }

        public static async Task<bool> TryInDfrntWindow(string config)
        {
            try
            {
                string batchFilePath = Comb(CrntProjLogFolder, "TryInDfrntWindow_buildcommand.bat"), logFile = Comb(CrntProjLogFolder, "TryInDfrntWindow_buildoutput.log");
                bool genSuccess = true;

                File.WriteAllLines(batchFilePath,
                [
                    $"@echo off",
                    $@"cd {ServiceProjFoldr}",
                    $"echo Current Directory: %cd%",
                    $"dotnet build \"{ServiceProjFullPath}\" --configuration {config}",
                    $"echo Done" // Optionalindicate completion
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
                    Log("Error while genearting Models!  Please see console for more details.");
                }
                try
                {
                    process.Kill(true);
                    await process.WaitForExitAsync();
                }
                catch (Exception ex)
                {
                    //Log($"Error killing process: {ex.Message}");
                    LogInfo(ex, LogFile, NameSpacesUsed);
                    return false;
                }

                // Read and display the output from the log file
                string output = File.ReadAllText(logFile);

                Log($"TryInDfrntWindow Output:{output}");
                // Clean up
                if (!File.Exists(batchFilePath))
                    File.Delete(batchFilePath);
                if (!File.Exists(logFile))
                    File.Delete(logFile);

                return genSuccess;
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                return false;
            }
        }

        public static async Task<bool> GenerateModel()
        {
            string tbls = Emp;
            bool genSuccess = true;
            List<Type> types = GetTypes();
            try
            {
                foreach (ServiceDetail service in ConfigServices.ServiceSet)
                {
                    string tblName = service.Table.Trim();
                    Type typ = Type.GetType($"{SqlIntegrationServices}.{tblName}, {SqlIntegrationServices}", throwOnError: false, ignoreCase: true);
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

                if (genSuccess && !await RebuildSqlIntegrationServices(ServiceProjFullPath))
                {
                    Log($"{SqlIntegrationServices} project could not be built!");
                    return false;
                }
                if (AddedServices is null)
                {
                    Log("Added services are null. No update in model is performed for them");
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                return false;
            }
        }

        public static async Task<bool> GenerateModel(string tbls)
        {
            try
            {
                string batchFilePath = Comb(CrntProjLogFolder, "EFDBFirstCmd.bat"), logFilePath = Comb(CrntProjLogFolder, "EFDBFirstCmdoutput.log");
                bool genSuccess = true;

                File.WriteAllLines(batchFilePath,
                [
                    "@echo off",
                    $@"cd {ServiceProjFoldr}",
                    "echo Current Directory: %cd%",
                    $"dotnet ef dbcontext scaffold \"{MFELConnStr}\" Microsoft.EntityFrameworkCore.SqlServer -o Models --no-pluralize " +
                    $"--use-database-names --context-namespace {SqlIntegrationServices} --namespace {SqlIntegrationServices} " +
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
                    genSuccess = false;
                //Problem("Error while genearting Models!  Please see console for more details.");
                try
                {
                    process.Kill(true);
                    await process.WaitForExitAsync();
                }
                catch (Exception ex)
                {
                    Log($"Error killing process: {ex.Message}");
                    return false;
                }

                // Read and display the output from the log file
                string output = File.ReadAllText(logFilePath);

                Log($"GenerateModel Output:{output}");
                // Clean up
                if (File.Exists(batchFilePath))
                    File.Delete(batchFilePath);
                if (File.Exists(logFilePath))
                    File.Delete(logFilePath);

                return genSuccess;
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed);
                return false;
            }
        }

        public static bool UpdtModel(string tableName, JObject? jObj, string filePath, Type? typ)
        {
            if (typ is null) return false;
            if (jObj is null) return false;

            try
            {
                HashSet<string> classProps = typ.GetProperties(BindingFlags.Instance | BindingFlags.Public).Select(p => p.Name).ToHashSet();
                HashSet<string> jsonProps = jObj.Properties().Select(p => p.Name).ToHashSet();

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

                    File.AppendAllText(filePath, classDef);
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

        public static List<Type> GetTypes()
        {
            try
            {
                string debugDll = Comb(DebugFolder, $"{SqlIntegrationServices}.dll");
                string rlzDll = Comb(RlzFolder, $"{SqlIntegrationServices}.dll");

                Assembly asmbly = Assembly.LoadFrom(rlzDll);
                asmbly ??= Assembly.LoadFrom(debugDll);

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

        public static string GetCSharpTypeFromJToken(JToken token)
        {
            try
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
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed, Emp, true);
                return null;
            }
        }

        public static async Task DeleteServices()
        {
            if (!(DeletedServices?.Count > 0)) return;
            try
            {
                foreach (ServiceDetail service in DeletedServices)
                {
                    //string filePath = Comb(CrntSolnFolder, $@"{SqlIntegrationServices}\Models\{service.Endpoint}.cs");
                    //if (File.Exists(filePath)) File.Delete(filePath);
                    DeletedServices.Remove(service);
                }
                //if (!await RebuildSqlIntegrationServices(ServiceProjFullPath))
                //    Log($"{SqlIntegrationServices} project could not be built after deleting services!");
            }
            catch (Exception ex)
            {
                LogInfo(ex, LogFile, NameSpacesUsed, "Error in deleting services:", true);
            }
        }

    }
}
