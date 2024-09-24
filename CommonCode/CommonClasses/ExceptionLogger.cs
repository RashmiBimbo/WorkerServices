using static CommonCode.CommonClasses.Common;

namespace CommonCode.CommonClasses
{
    public static class ExceptionLogger
    {
        /// <summary>
        /// Get exception and inner exception message and info which is related to projects in the solution
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="nameSpaces">name of namespaces whose stacktrace is required</param>
        /// <returns></returns>
        public static string GetRelErrorMsg(Exception ex, List<string> nameSpaces)
        {
            try
            {
                string relevantStackTrace = GetRelevantStackTrace(ex, nameSpaces);
                relevantStackTrace = ex?.Message + (IsEmpty(relevantStackTrace) ? Emp : $"{Entr}StackTrace: {relevantStackTrace}");

                if (IsEmpty(relevantStackTrace)) return Emp;

                if (ex.InnerException != null)
                {
                    string innerStackTrace = GetRelevantStackTrace(ex.InnerException, nameSpaces);
                    relevantStackTrace += $"{Entr}Inner Exception Details:" + ex.InnerException.Message;
                    relevantStackTrace += $"{Entr}StackTrace:" + (IsEmpty(innerStackTrace) ? Emp : $"{Entr}StackTrace: {innerStackTrace}");
                }
                return relevantStackTrace;
            }
            catch (Exception ex1)
            {
                Console.WriteLine($"{Entr}{DateTime.Now}: {ex1.Message}{Entr}StackTrace:{ex1.StackTrace}");
                return $"{Entr}StackTrace:{ex.StackTrace}";
            }
        }

        /// <summary>
        /// Get only stacktrace which is related to projects in the solution
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="nameSpaces">name of namespaces whose stacktrace is required</param>
        /// <returns></returns>
        private static string GetRelevantStackTrace(Exception ex, List<string> _projectNamespaces)
        {
            if (ex is null) return Emp;
            var stackTraceLines = ex.StackTrace?.Split(Entr);
            if (stackTraceLines == null) return Emp;

            string[]? relevantLines = stackTraceLines?
                .Where(line => _projectNamespaces.Any(ns => line.Contains(ns)))?
                .ToArray();
            if (!(relevantLines?.Length > 0)) return Emp;
            return string.Join(Entr, relevantLines).Trim();
        }
    }
}
