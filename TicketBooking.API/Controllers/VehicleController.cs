using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.BLL.DTOs.Booking;
using TicketBooking.BLL.DTOs.Vehicle;
using TicketBooking.BLL.Interfaces;

namespace TicketBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _service;

        public VehicleController(IVehicleService service)
        {
            _service = service;
        }

        // GET: api/vehicle
        [HttpGet]
        public async Task<ActionResult<List<VehicleCompanyDTO>>> GetAll()
        {
            var data = await _service.GetAllAsync();

            if (data == null || data.Count == 0)
            {
                return NotFound("No vehicles found");
            }
            else
            {
                return Ok(data);
            }
        }

        // GET: api/vehicle/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleCompanyDTO>> Get(int id)
        {
            var data = await _service.GetAsync(id);

            if (data == null)
            {
                return NotFound("Vehicle not found");
            }
            else
            {
                return Ok(data);
            }
        }

        // GET: api/vehicle/company/{companyId}
        [HttpGet("company/{companyId}")]
        public async Task<ActionResult<List<VehicleCompanyDTO>>> GetByCompany(int companyId)
        {
            var data = await _service.GetByCompanyAsync(companyId);

            if (data == null || data.Count == 0)
            {
                return NotFound("No vehicles found for this company");
            }
            else
            {
                return Ok(data);
            }
        }

        // GET: api/vehicle/route/{routeId}
        [HttpGet("route/{routeId}")]
        public async Task<ActionResult<List<VehicleRouteDTO>>> GetByRoute(int routeId)
        {
            var data = await _service.GetByRouteAsync(routeId);

            if (data == null || data.Count == 0)
            {
                return NotFound("No vehicles found for this route");
            }
            else
            {
                return Ok(data);
            }
        }

        // GET: api/vehicle/{vehicleId}/seats
        [HttpGet("{vehicleId}/seats")]
        public async Task<ActionResult<List<SeatDTO>>> GetAvailableSeats(int vehicleId)
        {
            var seats = await _service.GetAvailableSeatsAsync(vehicleId);

            if (seats == null || seats.Count == 0)
            {
                return NotFound("No available seats");
            }
            else
            {
                return Ok(seats);
            }
        }

        // POST: api/vehicle
        [HttpPost]
        public async Task<ActionResult> Create(/*[FromBody]*/ VehicleCreateDTO dto)
        {
            /*{
                "type": "Train",
                "CompanyId":4,
                "BaseFare":300.00,
                "RouteId": 3,
                "DepartureTime": "2026-02-10T08:00:00"
            }*/
            if (dto == null)
            {
                return BadRequest("Invalid data");
            }

            var success = await _service.CreateAsync(dto);

            if (success)
            {
                return Ok("Vehicle created successfully");
            }
            else
            {
                return BadRequest("Vehicle creation failed");
            }
        }

        //// DELETE: api/vehicle/{id}
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var success = await _service.DeleteAsync(id);

        //    if (success)
        //    {
        //        return Ok("Vehicle deleted successfully");
        //    }
        //    else
        //    {
        //        return NotFound("Vehicle not found");
        //    }
       // }
    }
}
