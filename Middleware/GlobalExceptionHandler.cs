using BookingSystem.Models.Exceptions;
using BookingSystem.Models.Responses;
using System.Net;
using System.Text.Json;

namespace BookingSystem.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var errorResponse = exception switch
            {
                ValidationException validationEx => new ErrorResponseWrapper(
                    HttpStatusCode.BadRequest,
                    new ValidationErrorResponse("Validation failed", validationEx.Errors)),
                UnauthorizedAccessException => new ErrorResponseWrapper(
                    HttpStatusCode.Unauthorized,
                    new ErrorResponse("Unauthorized access")),
                _ => new ErrorResponseWrapper(
                    HttpStatusCode.InternalServerError,
                    new ErrorResponse("An unexpected error occurred"))
            };

            response.StatusCode = (int)errorResponse.StatusCode;

            _logger.LogError(exception, "An error occurred: {Message}", exception.Message);

            var result = JsonSerializer.Serialize(errorResponse.Response);
            await response.WriteAsync(result);
        }
    }
} 