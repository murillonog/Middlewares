using Middlewares.Models;
using Newtonsoft.Json;
using System.Net;

namespace Middlewares.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            this.next = next;
            _logger = logger.CreateLogger("MyErrorHandler");
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorResponse = new ErrorResponse(HttpStatusCode.InternalServerError, exception.Message);

            _logger.LogError($"Error: {exception.Message}");
            _logger.LogError($"Stack: {exception.StackTrace}");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)errorResponse.StatusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }
}
