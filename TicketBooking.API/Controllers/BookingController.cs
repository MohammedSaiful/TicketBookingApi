using Microsoft.AspNetCore.Authorization;
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

        // GET: api/booking
        [HttpGet]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<ActionResult<List<BookingReadDTO>>> GetAll()
        {
            var bookings = await _service.GetAllAsync();

            if (bookings == null || bookings.Count == 0)
            {
                return NotFound("No bookings found.");
            }
            else
            {
                return Ok(bookings);
            }
        }

        // GET: api/booking/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<ActionResult<BookingReadDTO>> Get(int id)
        {
            var booking = await _service.GetAsync(id);

            if (booking == null)
            {
                return NotFound("Booking not found.");
            }
            else
            {
                return Ok(booking);
            }
        }

        // GET: api/booking/user/{userId}
        [HttpGet("user/{userId}")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<ActionResult<List<BookingReadDTO>>> GetByUser(int userId)
        {
            var bookings = await _service.GetByUserAsync(userId);

            if (bookings == null || bookings.Count == 0)
            {
                return NotFound("No bookings found for this user.");
            }
            else
            {
                return Ok(bookings);
            }
        }

        // GET: api/booking/details/{bookingId}
        [HttpGet("details/{bookingId}")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<ActionResult<BookingDetailsDTO>> GetDetails(int bookingId)
        {
            var booking = await _service.GetDetailsAsync(bookingId);

            if (booking == null)
            {
                return NotFound("Booking details not found.");
            }
            else
            {
                return Ok(booking);
            }
        }

        // POST: api/booking
        [HttpPost]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<ActionResult> Create(BookingCreateDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid booking data.");
            }

            var success = await _service.CreateAsync(dto);

            if (success == false)
            {
                return BadRequest("Booking creation failed.");
            }
            else
            {
                return Ok("Booking created successfully.");
            }
        }

        // PUT: api/booking/status
        [HttpPut("status")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> ChangeStatus(ChangeBookingStatusDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid status data.");
            }

            var success = await _service.ChangeStatusAsync(dto);

            if (success == false)
            {
                return NotFound("Booking not found or status change failed.");
            }
            else
            {
                return Ok("Booking status updated successfully.");
            }
        }

        // DELETE: api/booking/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);

            if (success == false)
            {
                return NotFound("Booking not found or delete failed.");
            }
            else
            {
                return Ok("Booking deleted successfully.");
            }
        }
    }
}
