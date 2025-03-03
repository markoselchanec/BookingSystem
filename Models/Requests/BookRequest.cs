using System.ComponentModel.DataAnnotations;
using BookingSystem.Models.Requests;

namespace BookingSystem.Models.Requests
{
    public class BookRequest
    {
        public BookRequest(string optionCode, SearchRequest searchRequest)
        {
            OptionCode = optionCode;
            SearchRequest = searchRequest;
        }

        public string OptionCode { get; }
        public SearchRequest SearchRequest { get; }
    }
} 