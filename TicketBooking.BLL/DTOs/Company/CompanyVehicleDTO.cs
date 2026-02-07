using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Search;

namespace TicketBooking.BLL.DTOs.Company
{
    public class CompanyVehicleDTO: CompanyReadDTO
    {
        public List<VehicleInfoDTO> Vehicles { get; set; }

        public CompanyVehicleDTO()
        {
            Vehicles = new List<VehicleInfoDTO>();
        }
    }
}
