using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.BLL.DTOs.Search;
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

        // GET: api/search/routes
        [HttpGet("routes")]
        public async Task<ActionResult<List<SearchRouteDTO>>> GetAllRoutes()
        {
            var routes = await _service.GetAllRoutesAsync();

            if (routes == null || routes.Count == 0)
            {
                return NotFound("No routes found.");
            }

            return Ok(routes);
        }

        // GET: api/search?origin=Dhaka&destination=Chittagong&date=2026-02-10
        [HttpGet]
        public async Task<ActionResult<List<VehicleDTO>>> Search(
            [FromQuery] string origin,
            [FromQuery] string destination,
            [FromQuery] DateTime? date)
        {
            if (string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(destination))
            {
                return BadRequest("Origin and Destination are required.");
            }

            var result = await _service.SearchAsync(origin, destination, date);

            if (result == null || result.Count == 0)
            {
                return NotFound("No vehicles found for the given search.");
            }

            return Ok(result);
        }

        // GET: api/search/with-vehicles?origin=Dhaka&destination=Chittagong
        [HttpGet("with-vehicles")]
        public async Task<ActionResult<List<SearchRouteVehicleDTO>>> SearchWithVehicles(
            [FromQuery] string origin,
            [FromQuery] string destination)
        {
            if (string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(destination))
            {
                return BadRequest("Origin and Destination are required.");
            }

            var routes = await _service.SearchWithVehiclesAsync(origin, destination);

            if (routes == null || routes.Count == 0)
            {
                return NotFound("No routes with vehicles found.");
            }

            return Ok(routes);
        }

        // GET: api/search/by-date?date=2026-02-10
        [HttpGet("by-date")]
        public async Task<ActionResult<List<SearchRouteVehicleDTO>>> SearchByDate(
            [FromQuery] DateTime date)
        {
            var routes = await _service.SearchByDateWithVehicleAsync(date);

            if (routes == null || routes.Count == 0)
            {
                return NotFound("No routes found for the given date.");
            }

            return Ok(routes);
        }
    }
}
