namespace BookingSystem.Models.Responses
{
    public class Option
    {
        public Option(string optionCode, string hotelCode, string flightCode, string arrivalAirport, double price)
        {
            this.OptionCode = optionCode;
            this.HotelCode = hotelCode;
            this.FlightCode = flightCode;
            this.ArrivalAirport = arrivalAirport;
            this.Price = price;
        }

        public string OptionCode { get; set; }
        public string HotelCode { get; set; }
        public string FlightCode { get; set; }
        public string ArrivalAirport { get; set; }
        public double Price { get; set; }
    }
}
