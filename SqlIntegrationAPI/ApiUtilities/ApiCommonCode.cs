using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using CommonCode.CommonClasses;
using static CommonCode.CommonClasses.Common;

namespace SqlIntegrationAPI.ApiUtilities
{
    internal static class ApiCommonCode
    {
        public static readonly string CrntProjName = nameof(SqlIntegrationAPI);
        public static readonly string CrntProjFolder, CrntProjPathFullPath;
        public static string crntProjLogFolder, logFile;
        public static readonly List<string> NameSpacesUsed;

        static ApiCommonCode()
        {
            CrntProjFolder = Comb(CrntSolnFolder, CrntProjName);
            CrntProjPathFullPath = Comb(CrntProjFolder, $"{CrntProjName}.csproj");
            NameSpacesUsed = [CrntProjName, nameof(CommonCode)];
        }

        public static string CrntProjLogFolder
        {
            get
            {
                if (IsEmpty(crntProjLogFolder) || !Directory.Exists(crntProjLogFolder))
                {
                    crntProjLogFolder = Comb(LogFolder, $"{nameof(SqlIntegrationAPI)}Logs");

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
                    logFile = Comb(CrntProjLogFolder, $"{CrntProjName}_Log.txt");

                    if (!File.Exists(logFile))
                    {
                        File.Create(logFile);
                        Console.WriteLine($"File created at: {logFile}");
                    }
                }
                return logFile;
            }
        }
    }
}
