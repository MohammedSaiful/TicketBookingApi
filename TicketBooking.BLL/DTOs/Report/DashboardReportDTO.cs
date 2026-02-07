using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.BLL.DTOs.Report
{
    public class DashboardReportDTO
    {
        public int TotalBookings { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
