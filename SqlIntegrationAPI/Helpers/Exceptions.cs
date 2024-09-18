
using System.Globalization;

namespace SqlIntegrationAPI.Helpers
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base() { }

        public NotFoundException(string message) : base(message) { }
    }

    public class AppException : Exception
    {
        public AppException() : base() { }

        public AppException(string message) : base(message) { }
    }
}
