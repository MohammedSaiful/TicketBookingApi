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

        // GET: api/payment
        [HttpGet]
        public async Task<ActionResult<List<PaymentReadDTO>>> GetAll()
        {
            var payments = await _service.GetAllAsync();

            if (payments == null || payments.Count == 0)
            {
                return NotFound("No payments found.");
            }
            else
            {
                return Ok(payments);
            }
        }

        // GET: api/payment/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentReadDTO>> Get(int id)
        {
            var payment = await _service.GetAsync(id);

            if (payment == null)
            {
                return NotFound("Payment not found.");
            }
            else
            {
                return Ok(payment);
            }
        }

        // POST: api/payment
        [HttpPost]
        public async Task<ActionResult> Create(PaymentCreateDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid payment data.");
            }

            var success = await _service.CreateAsync(dto);

            if (success == false)
            {
                return BadRequest("Payment creation failed.");
            }
            else
            {
                return Ok("Payment created successfully.");
            }
        }

        // PUT: api/payment/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PaymentCreateDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid payment data.");
            }

            var success = await _service.UpdateAsync(id, dto);

            if (success == false)
            {
                return NotFound("Payment update failed or payment not found.");
            }
            else
            {
                return Ok("Payment updated successfully.");
            }
        }

        // DELETE: api/payment/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);

            if (success == false)
            {
                return NotFound("Payment not found or delete failed.");
            }
            else
            {
                return Ok("Payment deleted successfully.");
            }
        }

        // GET: api/payment/revenue
        [HttpGet("revenue")]
        public async Task<ActionResult<decimal>> GetTotalRevenue()
        {
            var revenue = await _service.GetTotalRevenueAsync();

            if (revenue <= 0)
            {
                return Ok(0);
            }
            else
            {
                return Ok(revenue);
            }
        }
    }
}
