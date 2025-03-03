using BookingSystem.Enums;

namespace BookingSystem.Models.Responses
{
    public class CheckStatusResponse
    {
        public CheckStatusResponse(BookingStatusEnum status)
        {
            Status = status;
        }

        public BookingStatusEnum Status { get; }
    }
} 