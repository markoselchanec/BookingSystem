using BookingSystem.Models.Domain;
using BookingSystem.Models.Requests;
using BookingSystem.Models.Responses;

namespace BookingSystem.Storage.Abstract
{
    public interface IMemoryStore
    {
        void InsertSearchResponse(string optionCode, SearchResponse response);
        SearchResponse GetSearchResponse(string optionCode);
        void InsertBookingInfo(string bookingCode, BookingInfo bookingInfo);
        BookingInfo GetBookingInfo(string bookingCode);
    }
}