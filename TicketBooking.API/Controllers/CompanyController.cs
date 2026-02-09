using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.BLL.DTOs.Company;
using TicketBooking.BLL.Interfaces;

namespace TicketBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        // GET: api/company
        [HttpGet]
        public async Task<ActionResult<List<CompanyReadDTO>>> GetAll()
        {
            var companies = await _service.GetAllAsync();

            if (companies == null || companies.Count == 0)
            {
                return NotFound("No companies found.");
            }
            else
            {
                return Ok(companies);
            }
        }

        // GET: api/company/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyReadDTO>> Get(int id)
        {
            var company = await _service.GetAsync(id);

            if (company == null)
            {
                return NotFound("Company not found.");
            }
            else
            {
                return Ok(company);
            }
        }

        // GET: api/company/vehicles/{companyId}
        [HttpGet("vehicles/{companyId}")]
        public async Task<ActionResult<CompanyVehicleDTO>> GetWithVehicles(int companyId)
        {
            var company = await _service.GetWithVehiclesAsync(companyId);

            if (company == null)
            {
                return NotFound("Company not found or no vehicles available.");
            }
            else
            {
                return Ok(company);
            }
        }

        // POST: api/company
        [HttpPost]
        public async Task<ActionResult> Create(CompanyCreateDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid company data.");
            }

            var success = await _service.CreateAsync(dto);

            if (success == false)
            {
                return BadRequest("Company creation failed.");
            }
            else
            {
                return Ok("Company created successfully.");
            }
        }

        // PUT: api/company/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CompanyCreateDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid company data.");
            }

            var success = await _service.UpdateAsync(id, dto);

            if (success == false)
            {
                return NotFound("Company update failed or company not found.");
            }
            else
            {
                return Ok("Company updated successfully.");
            }
        }

        // DELETE: api/company/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);

            if (success == false)
            {
                return NotFound("Company not found or delete failed.");
            }
            else
            {
                return Ok("Company deleted successfully.");
            }
        }
    }
}
