using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.BLL.DTOs.Vehicle
{
    public class VehicleDetailsDTO
    {
        public int Id { get; set; }
        public string Type { get; set; } 
        public string CName { get; set; }
        public int RouteId { get; set; }
        public List<string> Seats { get; set; }
        public VehicleDetailsDTO() { 
        
            Seats = new List<string>();
        }
    }
}
