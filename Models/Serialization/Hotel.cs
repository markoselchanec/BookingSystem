using System.Text.Json.Serialization;

namespace BookingSystem.Models.Serialization
{
    public class Hotel
    {
        public Hotel(int id, int code, string name, string destinationCode, string city)
        {
            this.Id = id;
            this.Code = code;
            this.Name = name;
            this.DestinationCode = destinationCode;
            this.City = city;
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("hotelCode")]
        public int Code { get; set; }
        [JsonPropertyName("hotelName")]
        public string Name { get; set; }
        [JsonPropertyName("destinationCode")]
        public string DestinationCode { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
    }
} 