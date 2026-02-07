using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.BLL.DTOs.Vehicle
{
    public class VehicleRouteDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public string Origin { get; set; }
        public string Destination { get; set; }
    }
}
