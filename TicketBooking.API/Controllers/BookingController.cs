using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.BLL.DTOs.Booking;
using TicketBooking.BLL.Interfaces;

namespace TicketBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var list = await _service.GetByUserAsync(userId);
            return Ok(list);
        }

        [HttpGet("details/{bookingId}")]
        public async Task<IActionResult> GetDetails(int bookingId)
        {
            var data = await _service.GetDetailsAsync(bookingId);

            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookingCreateDTO dto)
        {
            var result = await _service.CreateAsync(dto);

            if (result)
            {
                return Ok("Created");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPatch("status")]
        public async Task<IActionResult> ChangeStatus(ChangeBookingStatusDTO dto)
        {
            var result = await _service.ChangeStatusAsync(dto);

            if (result)
            {
                return Ok("Updated");
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

            if (result)
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
