using BookingSystem.Models.Requests;
using BookingSystem.Models.Responses;

namespace BookingSystem.Services
{
    public interface IManager
    {
        Task<SearchResponse> Search(SearchRequest request);
        BookResponse Book(BookRequest request);
        CheckStatusResponse CheckStatus(CheckStatusRequest request);
    }
}