using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.BLL.DTOs.Vehicle
{
    public class VehicleCompanyDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal BaseFare { get; set; }

        public string CompanyName { get; set; }
    }
}
