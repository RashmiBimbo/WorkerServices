using static CommonCode.Common;

namespace CommonCode
{
    public class ExceptionLogger
    {
        private readonly List<string> _projectNamespaces;

        public ExceptionLogger(List<string> projectNamespaces) => _projectNamespaces = projectNamespaces;

        public string GetRelErrorMsg(Exception ex)
        {
            string relevantStackTrace = GetRelevantStackTrace(ex);
            relevantStackTrace = ex?.Message + (IsEmpty(relevantStackTrace) ? Emp : $"{Entr}StackTrace: {relevantStackTrace}");

            if (IsEmpty(relevantStackTrace)) return Emp;

            if (ex.InnerException != null)
            {
                string innerStackTrace = GetRelevantStackTrace(ex.InnerException);
                relevantStackTrace += $"{Entr}Inner Exception Details:" + ex.InnerException.Message;
                relevantStackTrace += $"{Entr}StackTrace:" + (IsEmpty(innerStackTrace) ? Emp : $"{Entr}StackTrace: {innerStackTrace}");
            }
            return relevantStackTrace;
        }

        private string GetRelevantStackTrace(Exception ex)
        {
            if (ex is null) return Emp;
            var stackTraceLines = ex.StackTrace?.Split(Entr);
            if (stackTraceLines == null) return Emp;

            var relevantLines = stackTraceLines
                .Where(line => _projectNamespaces.Any(ns => line.Contains(ns)))?
                .ToArray();

            return string.Join(Entr, relevantLines).Trim();
        }
    }
}
