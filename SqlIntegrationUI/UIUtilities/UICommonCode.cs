using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace SqlIntegrationUI.UIUtilities
{
    internal static class UICommonCode
    {
        public static IMemoryCache memoryCache;
        private static string crntProjLogFolder, logFile;
        public static readonly string CrntProjFolder, CrntProjPathFullPath;
        internal static readonly List<string> NameSpacesUsed;
        public static readonly string CrntProjName = nameof(SqlIntegrationUI);

        static UICommonCode()
        {
            memoryCache = new MemoryCache(new MemoryCacheOptions());

            CrntProjFolder = Path.Combine(CrntSolnFolder, CrntProjName);
            CrntProjPathFullPath = Path.Combine(CrntProjFolder, $"{CrntProjName}.csproj");

            NameSpacesUsed = [CrntProjName, nameof(CommonCode)];
        }

        public static string CrntProjLogFolder
        {
            get
            {
                if (IsEmpty(crntProjLogFolder) || !Directory.Exists(crntProjLogFolder))
                {
                    crntProjLogFolder = Path.Combine(LogFolder, $"{nameof(SqlIntegrationUI)}");

                    if (!Directory.Exists(crntProjLogFolder))
                    {
                        Directory.CreateDirectory(crntProjLogFolder);
                        Console.WriteLine($"Directory created at: {crntProjLogFolder}");
                    }
                }
                return crntProjLogFolder;
            }
        }

        public static string LogFile
        {
            get
            {
                if (IsEmpty(logFile) || !File.Exists(logFile))
                {
                    logFile = Path.Combine(CrntProjLogFolder, $"{CrntProjName}_Log.txt");

                    if (!File.Exists(logFile))
                    {
                        File.Create(logFile);
                        Console.WriteLine($"File created at: {logFile}");
                    }
                }
                return logFile;
            }
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
                catch (Exception ex)
                {
                    LogInfo(ex, LogFile, NameSpacesUsed);
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
                    Exception ex = new("The passed object is not of Service type!");
                    LogInfo(ex, LogFile, NameSpacesUsed);
                    throw ex;
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
                catch (Exception ex)
                {
                    LogInfo(ex, LogFile, NameSpacesUsed);
                    throw;
                }
            }
            set
            {
                if (value == null)
                {
                    memoryCache.Remove("AddedServices");
                }
                else if (value is Dictionary<string, JObject>)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60));
                    memoryCache.Set("AddedServices", value, cacheEntryOptions);
                }
                else
                {
                    Exception ex = new("The passed object is not of Dictionary<string, JObject> type!");
                    LogInfo(ex, LogFile, NameSpacesUsed);
                    throw ex;
                }
            }
        }

        public static HashSet<ServiceDetail> DeletedServices
        {
            get
            {
                try
                {
                    if (!memoryCache.TryGetValue("DeletedServices", out HashSet<ServiceDetail> DeletedServices))
                    {
                        var cacheEntryOpns = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60));
                        memoryCache.Set("DeletedServices", DeletedServices, cacheEntryOpns);
                    }
                    return DeletedServices;
                }
                catch (Exception ex)
                {
                    LogInfo(ex, LogFile, NameSpacesUsed);
                    throw;
                }
            }
            set
            {
                if (value == null)
                {
                    memoryCache.Remove("DeletedServices");
                }
                else if (value is HashSet<ServiceDetail>)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60));
                    memoryCache.Set("DeletedServices", value, cacheEntryOptions);
                }
                else
                {
                    Exception ex = new("The passed object is not of HashSet<ServiceDetail> type!");
                    LogInfo(ex, LogFile, NameSpacesUsed);
                    throw ex;
                }
            }
        }

        public static void Log(string msg, bool writeConsole = true, string logFile = null)
        {
            logFile ??= LogFile;
            LogMsg(logFile, $"{Entr}{DateTime.Now}:{msg}", writeConsole);
        }
    }
}
