using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.BLL.DTOs.Report
{
    public class TopRouteDTO
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int BookingCount { get; set; }
    }
}
