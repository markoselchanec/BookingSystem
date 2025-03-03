using System.Net;

namespace BookingSystem.Models.Responses
{
    public class ErrorResponseWrapper
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Response { get; set; }

        public ErrorResponseWrapper(HttpStatusCode statusCode, object response)
        {
            StatusCode = statusCode;
            Response = response;
        }
    }
} 