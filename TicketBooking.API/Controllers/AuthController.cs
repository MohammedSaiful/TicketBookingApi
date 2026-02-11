using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.BLL.DTOs.User;
using TicketBooking.BLL.Interfaces;

namespace TicketBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _service;
        public AuthController(IAuth service)
        {
            _service = service;
        }

        // POST: api/Auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data");
            }

            var result = await _service.RegisterAsync(dto);

            if (result)
            {
                return Ok("User registered successfully");
            }
            else
            {
                return BadRequest("Registration failed");
            }
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data");
            }

            var authResponse = await _service.LoginAsync(dto);

            if (authResponse != null)
            {
                return Ok(authResponse); // Return JWT token and user info
            }
            else
            {
                return Unauthorized("Invalid email or password");
            }
        }

    }
}
