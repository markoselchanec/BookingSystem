namespace BookingSystem.Models.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }

        public ValidationException(List<string> errors) 
            : base(string.Join(", ", errors))
        {
            Errors = errors;
        }
    }
} 