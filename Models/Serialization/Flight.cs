using System.Text.Json.Serialization;

namespace BookingSystem.Models.Serialization
{
    public class Flight
    {
        public Flight(int code, string number, string departureAirport, string arrivalAirport)
        {
            this.Code = code;
            this.Number = number;
            this.DepartureAirport = departureAirport;
            this.ArrivalAirport = arrivalAirport;
        }

        [JsonPropertyName("flightCode")]
        public int Code { get; set; }
        [JsonPropertyName("flightNumber")]
        public string Number { get; set; }
        [JsonPropertyName("departureAirport")]
        public string DepartureAirport { get; set; }
        [JsonPropertyName("arrivalAirport")]
        public string ArrivalAirport { get; set; }
    }
} 