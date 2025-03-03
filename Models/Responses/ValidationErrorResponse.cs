namespace BookingSystem.Models.Responses
{
    public class ValidationErrorResponse
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public ValidationErrorResponse(string message, List<string> errors)
        {
            Message = message;
            Errors = errors;
        }
    }
} 