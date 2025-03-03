using BookingSystem.Models.Requests;

namespace BookingSystem.Services.Abstract
{
    public interface IRequestValidator<T> where T : class
    {
        (bool IsValid, List<string> Errors) Validate(T request);
    }
} 