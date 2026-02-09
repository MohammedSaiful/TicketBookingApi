using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.BLL.Interfaces;

namespace TicketBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _service;

        public RecommendationController(IRecommendationService service)
        {
            _service = service;
        }

        [HttpGet("routes")]
        public async Task<IActionResult> Routes()
        {
            var data = await _service.GetTopRoutesAsync();
            return Ok(data);
        }

        [HttpGet("vehicles")]
        public async Task<IActionResult> Vehicles()
        {
            var data = await _service.GetPopularVehiclesAsync();
            return Ok(data);
        }
    }
}
