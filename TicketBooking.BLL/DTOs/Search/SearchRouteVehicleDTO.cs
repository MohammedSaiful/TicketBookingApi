using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.BLL.DTOs.Search
{
    public class SearchRouteVehicleDTO: SearchRouteDTO
    {
        public List<VehicleDTO> Vehicles { get; set; }

        public SearchRouteVehicleDTO()
        {
            Vehicles = new List<VehicleDTO>();
        }
    }
}
