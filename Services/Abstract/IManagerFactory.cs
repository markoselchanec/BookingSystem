using BookingSystem.Models.Requests;
using BookingSystem.Services.Concrete;
using BookingSystem.Storage.Abstract;

namespace BookingSystem.Services.Abstract
{
    public interface IManagerFactory
    {
        IManager CreateManager(SearchRequest request);
        IMemoryStore GetMemoryStore();
    }
} 