using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models.Requests
{
    public class SearchRequest
    {
        public SearchRequest(string destination, string departureAirport, DateTime fromDate, DateTime toDate)
        {
            Destination = destination;
            DepartureAirport = departureAirport;
            FromDate = fromDate;
            ToDate = toDate;
        }

        [Required]
        public string Destination { get; set; }
        public string DepartureAirport { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
    }
} 