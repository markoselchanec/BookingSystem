using BookingSystem.Models.Requests;
using BookingSystem.Models.Responses;
using BookingSystem.Services;
using BookingSystem.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckStatusController : ControllerBase
    {
        private readonly IManagerFactory _managerFactory;

        public CheckStatusController(IManagerFactory managerFactory)
        {
            _managerFactory = managerFactory;
        }

        [HttpPost]
        public ActionResult<CheckStatusResponse> CheckStatus([FromBody] CheckStatusRequest request)
        {
            var bookingInfo = _managerFactory.GetMemoryStore().GetBookingInfo(request.BookingCode);
            var manager = _managerFactory.CreateManager(bookingInfo.SearchRequest);
            var response = manager.CheckStatus(request);
            return Ok(response);
        }
    }
}
