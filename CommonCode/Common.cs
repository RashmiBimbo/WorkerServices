using CommonCode.Config;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net.Http.Headers;

namespace CommonCode
{
    public static class Common
    {
        public const string Emp = "";
        public static readonly string Entr = Environment.NewLine;
        public static readonly string ConnectionString = "Name=ConnectionStrings:DefaultConnection";
        public static readonly StringComparison StrComp = StringComparison.InvariantCultureIgnoreCase;
        public static IMemoryCache memoryCache;
        public static readonly string Resource = "https://mfprod.operations.dynamics.com";

        static Common()
        {
            memoryCache = new MemoryCache(new MemoryCacheOptions());
        }

        public static Services? Services
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

        public static Dictionary<string, JObject>? AddedServices
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

        public static string GetConfigFullPath()
        {
            string solnPath = GetSolnFolder();
            string ConfigFullPath = Path.Combine(solnPath, "Config.json");
            //Console.WriteLine(ConfigFullPath);
            return ConfigFullPath;
        }

        public static string GetSolnFolder()
        {
            string solnPath = Directory.GetCurrentDirectory();
            //Console.WriteLine(solnPath);
            string debugStr = @"\bin\Debug\net8.0";
            string rlzStr = @"\bin\Release\net8.0";
            solnPath = solnPath.Replace(debugStr, Emp, StrComp).Replace(rlzStr, Emp, StrComp);
            //Console.WriteLine(solnPath);
            solnPath = Directory.GetParent(solnPath).FullName;
            //Console.WriteLine(solnPath);
            return solnPath;
        }

        public static Services ReadConfig()
        {
            try
            {
                string ConfigJson = File.ReadAllText(GetConfigFullPath());
                Services services = JsonConvert.DeserializeObject<Services>(ConfigJson);
                return services;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static async Task<JObject> GetServiceJObject(ServiceDetail service)
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
                string msg = $"Error: {ex?.ToString()}";
                Console.WriteLine(msg);
                if (!IsEmpty(logFile))
                    File.AppendAllText(logFile, "\r\n" + msg);
                return null;
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