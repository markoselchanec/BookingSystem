using BookingSystem.Enums;
using BookingSystem.Helpers;
using BookingSystem.Models.Domain;
using BookingSystem.Models.Requests;
using BookingSystem.Models.Responses;
using BookingSystem.Models.Serialization;
using BookingSystem.Storage.Abstract;
using System.Text;
using System.Text.Json;

namespace BookingSystem.Services.Concrete
{
    public class HotelOnlyManager : IManager
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryStore _memoryStore;

        public HotelOnlyManager(HttpClient httpClient, IMemoryStore memoryStore)
        {
            _httpClient = httpClient;
            _memoryStore = memoryStore;
        }

        public async Task<SearchResponse> Search(SearchRequest request)
        {
            var response = new SearchResponse([]);

            var hotelsUrl = $"https://tripx-test-functions.azurewebsites.net/api/SearchHotels?destinationCode={request.Destination}";
            var hotelsResponse = await _httpClient.GetStringAsync(hotelsUrl);
            var hotels = JsonSerializer.Deserialize<List<Hotel>>(hotelsResponse);

            if (hotels is null || hotels.Count is 0)
            {
                return response;
            }

            foreach (var hotel in hotels)
            {
                var option = new Option(
                    Guid.NewGuid().ToString(),
                    hotel.Code.ToString(),
                    string.Empty,
                    request.Destination,
                    new Random().Next(100, 200));

                response.Options.Add(option);
                _memoryStore.InsertSearchResponse(option.OptionCode, response);
            }

            return response;
        }

        public BookResponse Book(BookRequest request)
        {
            var searchResponse = _memoryStore.GetSearchResponse(request.OptionCode) 
                ?? throw new ArgumentException("Invalid OptionCode.");

            var bookingCode = BookingCodeGenerator.Generate();
            var sleepTime = new Random().Next(30, 61);
            var bookingTime = DateTime.Now;

            var bookingInfo = new BookingInfo(bookingCode, bookingTime, sleepTime, request.SearchRequest);

            _memoryStore.InsertBookingInfo(bookingCode, bookingInfo);

            return new BookResponse(bookingCode, bookingTime);
        }

        public CheckStatusResponse CheckStatus(CheckStatusRequest request)
        {
            var bookingInfo = _memoryStore.GetBookingInfo(request.BookingCode)
                ?? throw new ArgumentException("Invalid BookingCode.");

            var elapsedTime = (DateTime.Now - bookingInfo.BookingTime).TotalSeconds;

            if (elapsedTime < bookingInfo.SleepTime)
            {
                return new CheckStatusResponse(BookingStatusEnum.Pending);
            }

            return new CheckStatusResponse(BookingStatusEnum.Success);
        }
    }
} 