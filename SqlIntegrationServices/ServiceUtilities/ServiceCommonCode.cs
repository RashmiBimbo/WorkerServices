using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace SqlIntegrationServices.ServiceUtilities
{
    internal static class ServiceCommonCode
    {
        public static readonly string LogFile;
        public static readonly string CrntProjName = nameof(SqlIntegrationServices);
        public static readonly string CrntProjFolder, LogFolder, CrntProjPathFullPath;
        public static readonly List<string> NameSpacesUsed;

        static ServiceCommonCode()
        {
            CrntProjFolder = Path.Combine(CrntSolnFolder, CrntProjName);
            LogFolder = Path.Combine(CrntSolnFolder, "Logs");
            CrntProjPathFullPath = Path.Combine(CrntProjFolder, $"{CrntProjName}.csproj");
            LogFile = Path.Combine(LogFolder, $"{CrntProjName}_Log.txt");
            NameSpacesUsed = [CrntProjName, nameof(CommonCode)];
        }
    }
}
