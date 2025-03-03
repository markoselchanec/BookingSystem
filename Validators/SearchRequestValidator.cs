using BookingSystem.Models.Requests;
using BookingSystem.Services.Abstract;

namespace BookingSystem.Validators
{
    public class SearchRequestValidator : IRequestValidator<SearchRequest>
    {
        public (bool IsValid, List<string> Errors) Validate(SearchRequest request)
        {
            var errors = new List<string>();

            if (request == null)
            {
                errors.Add("Search request cannot be null");
                return (false, errors);
            }

            if (string.IsNullOrWhiteSpace(request.Destination))
                errors.Add("Destination is required");

            if (request.FromDate == default)
                errors.Add("From date is required");

            if (request.ToDate == default)
                errors.Add("To date is required");

            if (request.FromDate >= request.ToDate)
                errors.Add("From date must be before to date");

            if (request.FromDate < DateTime.Now)
                errors.Add("From date cannot be in the past");

            if (!string.IsNullOrWhiteSpace(request.DepartureAirport))
            {
                if (request.DepartureAirport.Length != 3)
                    errors.Add("Departure airport code must be 3 characters");

                if (request.DepartureAirport == request.Destination)
                    errors.Add("Departure airport cannot be the same as destination");
            }

            return (errors.Count == 0, errors);
        }
    }
}