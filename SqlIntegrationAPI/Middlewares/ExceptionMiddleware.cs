using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SqlIntegrationAPI.Helpers;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SqlIntegrationAPI.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
    {
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception error)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";

                response.StatusCode = error switch
                {
                    AppException e => (int)HttpStatusCode.BadRequest,// custom application error
                    NotFoundException e => (int)HttpStatusCode.NotFound,// not found error
                    _ => (int)HttpStatusCode.InternalServerError,// unhandled error
                };
                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);

                {
                    //    var errId = Guid.NewGuid();
                    //    logger.LogError(ex, message: $"{errId}:{ex.Message}");

                    //    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    //    httpContext.Response.ContentType = "application/json";
                    //    //var problemDetails = new ProblemDetails()
                    //    //{
                    //    //    Detail = string.Empty,
                    //    //    Status = (int)HttpStatusCode.InternalServerError,

                    //    //};
                    //    var error = new
                    //    {
                    //        Id = errId,
                    //        ErrorMessage = $"Sorry, something went wrong! Here's the Error: \"{errId}:{ex.Message}\""
                    //    };
                    //    await httpContext.Response.WriteAsJsonAsync(error);
                }
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}