using System;

namespace BookingSystem.Models.Responses
{
    public class BookResponse
    {
        public BookResponse(string bookingCode, DateTime bookingTime)
        {
            BookingCode = bookingCode;
            BookingTime = bookingTime;
        }

        public string BookingCode { get; }
        public DateTime BookingTime { get; }
    }
} 