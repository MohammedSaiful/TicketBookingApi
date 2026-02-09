using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.BLL.DTOs.Report;
using TicketBooking.BLL.Interfaces;

namespace TicketBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        // GET: api/report/dashboard
        [HttpGet("dashboard")]
        public async Task<ActionResult<DashboardReportDTO>> GetDashboard()
        {
            var dashboard = await _service.GetDashboardAsync();

            if (dashboard == null)
            {
                return NotFound("Dashboard data not found.");
            }
            else
            {
                return Ok(dashboard);
            }
        }

        // GET: api/report/top-routes
        [HttpGet("top-routes")]
        public async Task<ActionResult<List<TopRouteDTO>>> GetTopRoutes()
        {
            var routes = await _service.GetTopRoutesAsync();

            if (routes == null || routes.Count == 0)
            {
                return NotFound("No top routes found.");
            }
            else
            {
                return Ok(routes);
            }
        }

        // GET: api/report/revenue
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
