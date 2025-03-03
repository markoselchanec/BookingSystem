using BookingSystem.Models.Exceptions;
using BookingSystem.Models.Requests;
using BookingSystem.Models.Responses;
using BookingSystem.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IManagerFactory _managerFactory;
        private readonly IRequestValidator<SearchRequest> _searchRequestValidator;

        public SearchController(
            IManagerFactory managerFactory,
            IRequestValidator<SearchRequest> searchRequestValidator)
        {
            _managerFactory = managerFactory;
            _searchRequestValidator = searchRequestValidator;
        }

        [HttpPost]
        public async Task<ActionResult<SearchResponse>> Search([FromBody] SearchRequest request)
        {
            var (isValid, errors) = _searchRequestValidator.Validate(request);
            if (!isValid)
                throw new ValidationException(errors);

            var manager = _managerFactory.CreateManager(request);
            return Ok(await manager.Search(request));
        }
    }
}
