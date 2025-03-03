using BookingSystem.Models.Requests;
using BookingSystem.Models.Responses;
using BookingSystem.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IManagerFactory _managerFactory;

        public BookController(IManagerFactory managerFactory)
        {
            _managerFactory = managerFactory;
        }

        [HttpPost]
        public ActionResult<BookResponse> Book([FromBody] BookRequest request)
        {
            var manager = _managerFactory.CreateManager(request.SearchRequest);
            var response = manager.Book(request);
            return Ok(response);
        }
    }
}
