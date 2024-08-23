using static CommonCode.Common;

namespace CommonCode
{
    public static class ExceptionLogger
    {
        public static string GetRelErrorMsg(Exception ex, List<string> nameSpaces)
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
