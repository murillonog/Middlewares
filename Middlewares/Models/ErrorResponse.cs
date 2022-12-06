using System.Net;

namespace Middlewares.Models
{
    public class ErrorResponse
    {
        public ErrorResponse(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

    }
}
