using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.BLL.Interfaces;

namespace TicketBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _service;

        public SearchController(ISearchService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string origin, string destination, DateTime? date)
        {
            var result = await _service.SearchAsync(origin, destination, date);
            return Ok(result);
        }
    }
}
