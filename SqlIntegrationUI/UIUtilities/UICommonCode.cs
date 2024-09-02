using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace SqlIntegrationUI.UIUtilities
{
    internal static class UICommonCode
    {
        public static IMemoryCache memoryCache;
        public static readonly string LogFile, CrntProjFolder, CrntProjPathFullPath;
        public static readonly List<string> NameSpacesUsed;
        public static readonly string CrntProjName = nameof(SqlIntegrationUI);

        static UICommonCode()
        {
            memoryCache = new MemoryCache(new MemoryCacheOptions());

            CrntProjFolder = Path.Combine(CrntSolnFolder, CrntProjName);
            CrntProjPathFullPath = Path.Combine(CrntProjFolder, $"{CrntProjName}.csproj");
            LogFile = Path.Combine(CrntProjFolder, $"{CrntProjName}_Log.txt");

            NameSpacesUsed = [CrntProjName, nameof(CommonCode)];
        }

        public static Services? ConfigServices
        {
            get
            {
                try
                {
                    if (!memoryCache.TryGetValue("ConfigServices", out Services services))
                    {
                        services = ReadConfig(ConfigFullPath);
                        var cacheEntryOpns = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60));
                        memoryCache.Set("ConfigServices", services, cacheEntryOpns);
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
                    memoryCache.Remove("ConfigServices");
                }
                else if (value is Services)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60));
                    memoryCache.Set("ConfigServices", value, cacheEntryOptions);
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
                    memoryCache.Remove("ConfigServices");
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
    }
}
