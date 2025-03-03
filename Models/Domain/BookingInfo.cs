using BookingSystem.Models.Requests;

namespace BookingSystem.Models.Domain
{
    public class BookingInfo
    {
        public BookingInfo(string bookingCode, DateTime bookingTime, int sleepTime, SearchRequest searchRequest)
        {
            BookingCode = bookingCode;
            BookingTime = bookingTime;
            SleepTime = sleepTime;
            SearchRequest = searchRequest;
        }

        public string BookingCode { get; }
        public DateTime BookingTime { get; }
        public int SleepTime { get; }
        public SearchRequest SearchRequest { get; }
    }
}
