﻿using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace SqlIntegrationServices.ServiceUtilities
{
    internal static class ServiceCommonCode
    {
        public static readonly string CrntProjName = nameof(SqlIntegrationServices);
        public static readonly string CrntProjFolder, CrntProjPathFullPath;
        public static string crntProjLogFolder, logFile;
        public static readonly List<string> NameSpacesUsed;

        static ServiceCommonCode()
        {
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
                    crntProjLogFolder = Path.Combine(LogFolder, $"{nameof(SqlIntegrationServices)}Logs");

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
    }
}
