using CommonCode.Config;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace CommonCode
{
    public static class Common
    {
        private static string crntSolnFolder, configFullPath, appFolder, logFolder;
        public const string SqlIntegrationUI = nameof(SqlIntegrationUI);
        public const string SqlIntegrationServices = nameof(SqlIntegrationServices);
        public static readonly string Emp = string.Empty;
        public static readonly string Entr = Environment.NewLine;
        public static readonly string MFELConnStr = "Name=MFELConnStr";
        public static readonly string ERP_SQL_ConnStr = "Name=ERP_SQL_ConnStr";
        public static readonly string Resource = "https://mfprod.operations.dynamics.com";
        public static readonly StringComparison StrComp = StringComparison.InvariantCultureIgnoreCase;
        private static readonly object fileLock = new();

        public static Func<string, string, string> Comb => Path.Combine;

        public static string CrntSolnFolder
        {
            get
            {
                crntSolnFolder = IsEmpty(crntSolnFolder) ? GetSolnFolder() : crntSolnFolder;
                return crntSolnFolder;
            }
        }

        public static string ProgramDataAppFolder
        {
            get
            {
                if (IsEmpty(appFolder) || !Directory.Exists(appFolder))
                {
                    string programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                    appFolder = Path.Combine(programFilesPath, "ErpSqlIntegration");

                    if (!Directory.Exists(appFolder))
                    {
                        Directory.CreateDirectory(appFolder);
                        Console.WriteLine($"Directory created at: {appFolder}");
                    }
                }
                return appFolder;
            }
        }

        public static string LogFolder
        {
            get
            {
                if (IsEmpty(logFolder) || !Directory.Exists(logFolder))
                {
                    logFolder = Path.Combine(ProgramDataAppFolder, "Logs");

                    if (!Directory.Exists(logFolder))
                    {
                        Directory.CreateDirectory(logFolder);
                        Console.WriteLine($"Directory created at: {logFolder}");
                    }
                }
                return logFolder;
            }
        }

        public static string ConfigFullPath
        {
            get
            {
                configFullPath = IsEmpty(configFullPath) ? GetConfigFullPath() : configFullPath;
                return configFullPath;
            }
        }

        static Common()
        { }

        private static string GetConfigFullPath(string solnFolder = null)
        {
            //solnFolder = IsEmpty(solnFolder) ? GetSolnFolder() : solnFolder;
            string configFullPath = Path.Combine(ProgramDataAppFolder, "Config.json");
            if (IsEmpty(configFullPath)) throw new Exception("Config file full path not found!");
            //Console.WriteLine(configFullPath);
            return configFullPath;
        }

        private static string GetSolnFolder()
        {
            string exeLocn = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (IsEmpty(exeLocn)) throw new Exception("Executing assembly path was not found!");
            string rlzStr = @"\bin\Release\net8.0";
            string dbgStr = @"\bin\Debug\net8.0";
            string solnFolder = exeLocn.Replace(rlzStr, Emp, StrComp).Replace(dbgStr, Emp, StrComp).Replace($"publish-{SqlIntegrationServices}", Emp, StrComp).Replace($"publish-{SqlIntegrationUI}", Emp, StrComp).Replace(SqlIntegrationServices, Emp, StrComp).Replace(SqlIntegrationUI, Emp, StrComp);
            //int i = exeLocn.IndexOf("\\ERP_SQL_Integration\\", StrComp) + "ERP_SQL_Integration".Length;
            //string solnFolder = exeLocn[..(i + 1)];
            //Console.WriteLine(solnFolder);
            return solnFolder;
        }

        public static Services ReadConfig(string configFullPath = "", bool throwIfUnAvlbl = false)
        {
            Services services;
            try
            {
                try
                {
                    configFullPath = IsEmpty(configFullPath) ? GetConfigFullPath() : configFullPath;
                }
                catch (Exception ex)
                {
                    configFullPath = null;
                }
                if (IsEmpty(configFullPath) || !File.Exists(configFullPath))
                {
                    Console.WriteLine("Config not found;");
                    if (throwIfUnAvlbl) throw new FileNotFoundException();

                    File.Create(configFullPath);
                }
                string configJson = File.ReadAllText(configFullPath);
                if (IsEmpty(configJson))
                    services = new();
                else
                    services = DeserializeJson<Services>.Deserialize(configJson);
                return services;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Services ReadConfigLockd()
        {
            try
            {
                string configFullPath = ConfigFullPath;
                using FileStream fs = new(configFullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using StreamReader reader = new(fs, Encoding.UTF8);
                {
                    string configJson = reader.ReadToEnd();
                    Services services = DeserializeJson<Services>.Deserialize(configJson);
                    return services;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static async Task LockNWriteToConfig(string objectKey, string propertyKey, string newValue, string logFile)
        {
            lock (fileLock)
            {
                try
                {
                    string configPath = GetConfigFullPath();
                    string tempFilePath = Path.GetTempFileName();
                    using (FileStream fs = new(configPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader reader = new(fs, Encoding.UTF8))
                    using (StreamWriter writer = new(tempFilePath, false, Encoding.UTF8))
                    {
                        string line;
                        bool inTargetObject = false;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains($"\"{objectKey}\""))
                                inTargetObject = true;

                            if (inTargetObject && line.Contains($"\"{propertyKey}\""))
                            {
                                // Replace the line with the updated value
                                string updatedLine = $"  \"{propertyKey}\": \"{newValue}\",";
                                writer.WriteLine(updatedLine);
                            }
                            else
                                writer.WriteLine(line);


                            if (inTargetObject && line.Trim().EndsWith("}"))
                                inTargetObject = false;
                        }
                    }

                    // Replace the original file with the modified one atomically
                    File.Replace(tempFilePath, configPath, null);
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"An I/O error occurred: {ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    throw;
                }
            }
        }

        public static async Task<JObject> GetServiceJObject(ServiceDetail service)
        {
            JObject jObjRslt = null;
            string result = Emp;
            try
            {
                string and = IsEmpty(service.QueryString) ? Emp : "&";
                string url = $"{Resource}/data/{service.Endpoint}?{service.QueryString}{and}$top=1";
                for (int cnt = 1; cnt <= 2; cnt++)
                {
                    result = await GetJson(Resource, url);
                    if (!IsEmpty(result))
                        break;
                }
            }
            catch (Exception ex) { }

            if (IsEmpty(result)) return null;
            JObject obj = JObject.Parse(result);
            JArray Items = (JArray)obj["value"];

            for (int cnt = 1; cnt <= 2; cnt++)
            {
                try
                {
                    if (!(Items?.Count > 0)) return null;
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

        /// <summary>
        /// checks if string is null, empty or just white space
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsEmpty(string input)
        {
            try
            {
                return string.IsNullOrWhiteSpace(input);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static async Task<List<Column>> GetColumns(JObject jObj = null, ServiceDetail service = null)
        {
            List<Column> columns = null;
            try
            {
                if (jObj is null)
                    if (service is not null)
                        jObj = await GetServiceJObject(service);
                    else
                        ArgumentNullException.ThrowIfNull(service);
                if (jObj is null) return null;
                columns = jObj.Properties().Select(p => new Column() { Name = p.Name, Include = true }).ToList();
                columns.ForEach(col => { if (col.Name == "@odata.etag") { col.Name = "Etag"; } });
                return columns;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DateTimeOffset? TryCastDTO(dynamic itm)
        {
            try
            {
                string itmString = itm?.ToString(); // Convert input to string
                return DateTimeOffset.TryParse(itmString, out DateTimeOffset dto) ? dto : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex?.ToString()}");
                return null;
            }
        }

        /// <summary>
        /// Cast the input parameter to double. Returns 0.0 if fails
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double TryCastDbl(dynamic input)
        {
            try
            {
                string itmString = input?.ToString(); // Convert input to string
                return double.TryParse(itmString, out double dbl) ? dbl : 0.0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex?.ToString()}");
                return 0.0;
            }
        }

        public static long? TryCastLong(dynamic itm)
        {
            try
            {
                string itmString = itm?.ToString(); // Convert input to string
                return long.TryParse(itmString, out long lng) ? lng : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex?.ToString()}");
                return null;
            }
        }

        public static async Task<string?> GetJson(string resource, string url, string logFile = null)
        {
            string? result = null;
            string clientId = "f59652f6-fd73-411b-ba47-5002f217eff9";
            string clientSecret = "R1Z8Q~-nETEjRazu1X4qxi6C1~PTJsCkz-y~ccid";
            string tenantId = "cc53a9a2-48fc-49e7-8f12-ef5a565cbcbe";
            string authority = $"https://login.microsoftonline.com/{tenantId}/oauth2/token";
            //string url = $"{resource}/{url}";

            using var client = new HttpClient();
            var content = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret),
                new KeyValuePair<string, string>("resource", resource)
            ]);

            try
            {
                var tokenResponse = await client.PostAsync(authority, content);
                tokenResponse.EnsureSuccessStatusCode();

                var tokenJson = await tokenResponse.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<TokenResponse>(tokenJson);

                if (token != null && !string.IsNullOrEmpty(token.AccessToken))
                {
                    string apiUrl = url;
                    using HttpClient httpClient = new();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                    httpClient.Timeout = TimeSpan.FromMinutes(5.0);

                    var response = await httpClient.GetAsync(apiUrl);

                    if (!response.IsSuccessStatusCode)
                    {
                        string msg = $"HTTP request failed with status code: {response.StatusCode}";
                        Console.WriteLine(msg);
                        if (!IsEmpty(logFile))
                            File.AppendAllText(logFile, "\r\n" + msg);
                        return null;
                    }
                    result = await response.Content.ReadAsStringAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void LogInfo(Exception ex, string logFile, List<string> NameSpaces, string customMsg = "", bool writeConsole = false)
        {
            try
            {
                string msg = $"{Entr}{customMsg}{Entr}{DateTime.Now}: Error: {ExceptionLogger.GetRelErrorMsg(ex, NameSpaces)}";
                LogMsg(logFile, msg, writeConsole);
            }
            catch (Exception ex1)
            {
                Console.WriteLine($"{Entr}{DateTime.Now}: {ex.Message}{Entr}{ExceptionLogger.GetRelErrorMsg(ex, NameSpaces)}");
                Console.WriteLine($"{Entr}{DateTime.Now}: {ex1.Message}{Entr}{ExceptionLogger.GetRelErrorMsg(ex1, NameSpaces)}");
            }
        }

        public static void LogMsg(string logFile, string msg, bool writeConsole = true)
        {
            try
            {
                File.AppendAllText(logFile, msg);
                if (writeConsole)
                    Console.WriteLine(msg + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now}: {msg}");
                Console.WriteLine($"{DateTime.Now}: {ExceptionLogger.GetRelErrorMsg(ex, [nameof(CommonCode)])}");
            }
        }

    }

    public class TokenResponse
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }

        [JsonProperty("ext_expires_in")]
        public string ExtExpiresIn { get; set; }

        [JsonProperty("expires_on")]
        public string ExpiresOn { get; set; }

        [JsonProperty("not_before")]
        public string NotBefore { get; set; }

        [JsonProperty("resource")]
        public string Resource { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }

    public static class Serialize
    {
        public static string ToJson<T>(this T self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public partial class DeserializeJson<T> where T : notnull
    {
        public static T Deserialize(string json) => JsonConvert.DeserializeObject<T>(json, settings: Converter.Settings);
    }

    public static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new()
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

}