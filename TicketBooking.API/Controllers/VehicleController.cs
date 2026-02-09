using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetAsync(id);

            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet("{id}/seats")]
        public async Task<IActionResult> GetSeats(int id)
        {
            var seats = await _service.GetAvailableSeatsAsync(id);
            return Ok(seats);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleCreateDTO dto)
        {
            var result = await _service.CreateAsync(dto);

            if (result == true)
            {
                return Ok("Created");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (result == true)
            {
                return Ok("Deleted");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
