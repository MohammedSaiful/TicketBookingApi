using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.BLL.DTOs.Company
{
    public class VehicleInfoDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int CompanyId { get; set; } //
        public string CompanyName { get; set; }
        public int RouteId { get; set; }

        public decimal BaseFare { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
