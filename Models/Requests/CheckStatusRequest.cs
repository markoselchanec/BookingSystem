using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models.Requests
{
    public class CheckStatusRequest
    {
        public CheckStatusRequest(string bookingCode)
        {
            BookingCode = bookingCode;
        }

        public string BookingCode { get; }
    }
} 