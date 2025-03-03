using BookingSystem.Enums;
using BookingSystem.Models.Requests;
using BookingSystem.Services.Abstract;
using BookingSystem.Services.Concrete;
using BookingSystem.Storage.Abstract;

namespace BookingSystem.Services
{
    public class ManagerFactory : IManagerFactory
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryStore _memoryStore;

        public ManagerFactory(IHttpClientFactory httpClientFactory, IMemoryStore memoryStore)
        {
            _httpClient = httpClientFactory.CreateClient();
            _memoryStore = memoryStore;
        }

        public IManager CreateManager(SearchRequest request)
        {
            var managerType = DetermineManagerType(request);
            return managerType switch
            {
                ManagerType.HotelOnly => new HotelOnlyManager(_httpClient, _memoryStore),
                ManagerType.HotelAndFlight => new HotelAndFlightManager(_httpClient, _memoryStore),
                ManagerType.LastMinuteHotels => new LastMinuteHotelsManager(_httpClient, _memoryStore),
                _ => throw new ArgumentException($"Unknown manager type: {managerType}")
            };
        }

        public IMemoryStore GetMemoryStore()
        {
            return _memoryStore;
        }

        private ManagerType DetermineManagerType(SearchRequest request)
        {
            if ((request.FromDate - DateTime.Now).TotalDays <= 45)
            {
                return ManagerType.LastMinuteHotels;
            }
            else if (!string.IsNullOrEmpty(request.DepartureAirport))
            {
                return ManagerType.HotelAndFlight;
            }
            else
            {
                return ManagerType.HotelOnly;
            }
        }
    }
}