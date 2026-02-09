using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.BLL.DTOs.Payment;
using TicketBooking.BLL.Interfaces;

namespace TicketBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
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

        [HttpPost]
        public async Task<IActionResult> Create(PaymentCreateDTO dto)
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

        [HttpGet("revenue")]
        public async Task<IActionResult> GetRevenue()
        {
            var revenue = await _service.GetTotalRevenueAsync();
            return Ok(revenue);
        }
    }
}
