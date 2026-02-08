using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.BLL.DTOs.Recommendation
{
    public class PopularVehicleDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int BookingCount { get; set; }
    }
}
