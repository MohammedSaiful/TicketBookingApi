using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.BLL.DTOs.User;
using TicketBooking.BLL.Interfaces;

namespace TicketBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        // POST: api/user/register
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

        // POST: api/user/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data");
            }

            var user = await _service.LoginAsync(dto);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return Unauthorized("Invalid email or password");
            }
        }

        // GET: api/user
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _service.GetAsync(id);

            if (user == null)
            {
                return NotFound("User not found");
            }
            else
            {
                return Ok(user);
            }
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserRegisterDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data");
            }

            var result = await _service.UpdateAsync(id, dto);

            if (result)
            {
                return Ok("User updated successfully");
            }
            else
            {
                return NotFound("User not found");
            }
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (result)
            {
                return Ok("User deleted successfully");
            }
            else
            {
                return NotFound("User not found");
            }
        }
    }
}
