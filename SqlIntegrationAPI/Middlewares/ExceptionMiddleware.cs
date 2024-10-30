using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Serilog;
using SqlIntegrationAPI.Helpers;

namespace SqlIntegrationAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception error)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";

                // Generate a unique error ID for tracking
                var errorId = Guid.NewGuid();

                // Set response status code based on the exception type
                response.StatusCode = error switch
                {
                    AppException => (int)HttpStatusCode.BadRequest, // custom application error
                    NotFoundException => (int)HttpStatusCode.NotFound, // not found error
                    _ => (int)HttpStatusCode.InternalServerError, // unhandled error
                };

                // Log the exception details using Serilog's Log class
                Log.Error(error, "Error ID: {ErrorId}, Exception: {ErrorMessage}, StackTrace: {StackTrace}",
                          errorId, error.Message, error.StackTrace);

                // Create a response containing the error ID and message
                var result = JsonSerializer.Serialize(new
                {
                    errorId,
                    message = "An unexpected error occurred. Please refer to the error ID for more details.",
                });

                await response.WriteAsync(result);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
