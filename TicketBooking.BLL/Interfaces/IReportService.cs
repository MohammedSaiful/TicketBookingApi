using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Report;

namespace TicketBooking.BLL.Interfaces
{
    public interface IReportService
    {
        Task<DashboardReportDTO> GetDashboardAsync();
        Task<List<TopRouteDTO>> GetTopRoutesAsync();
        Task<decimal> GetTotalRevenueAsync();
    }
}
