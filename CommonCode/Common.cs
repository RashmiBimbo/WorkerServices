using Azure;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;
using System.Net.Http.Headers;

namespace CommonCode
{
    public class Common
    {
        public const string Emp = "";

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

        public static DateTimeOffset? TryCastDTO(dynamic itm)
        {
            try
            {
                string itmString = itm?.ToString(); // Convert itm to string
                return DateTimeOffset.TryParse(itmString, out DateTimeOffset dto) ? dto : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex?.ToString()}");
                return null;
            }
        }

        public static double? TryCastDbl(dynamic itm)
        {
            try
            {
                string itmString = itm?.ToString(); // Convert itm to string
                return double.TryParse(itmString, out double dbl) ? dbl : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex?.ToString()}");
                return null;
            }
        }

        public static long? TryCastLong(dynamic itm)
        {
            try
            {
                string itmString = itm?.ToString(); // Convert itm to string
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