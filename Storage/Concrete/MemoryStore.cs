using BookingSystem.Models.Domain;
using BookingSystem.Models.Requests;
using BookingSystem.Models.Responses;
using BookingSystem.Storage.Abstract;

namespace BookingSystem.Storage.Concrete
{
    public class MemoryStore : IMemoryStore
    {
        private readonly Dictionary<string, SearchResponse> _searchResponses = new();
        private readonly Dictionary<string, BookingInfo> _bookingInfos = new();

        public void InsertSearchResponse(string optionCode, SearchResponse response)
        {
            _searchResponses[optionCode] = response;
        }

        public SearchResponse GetSearchResponse(string optionCode)
        {
            return _searchResponses.TryGetValue(optionCode, out var response)
                ? response
                : throw new ArgumentException($"Search response not found for option code: {optionCode}");
        }

        public void InsertBookingInfo(string bookingCode, BookingInfo bookingInfo)
        {
            _bookingInfos[bookingCode] = bookingInfo;
        }

        public BookingInfo GetBookingInfo(string bookingCode)
        {
            return _bookingInfos.TryGetValue(bookingCode, out var response)
                ? response
                : throw new ArgumentException($"Booking response not found for booking code: {bookingCode}");
        }
    }
}