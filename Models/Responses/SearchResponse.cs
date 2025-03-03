using System.Collections.Generic;

namespace BookingSystem.Models.Responses
{
    public class SearchResponse
    {
        public SearchResponse(List<Option> options)
        {
            Options = options;
        }

        public List<Option> Options { get; }
    }
} 