using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.BLL.DTOs.Search
{
    public class SearchRouteDTO
    {
        public int Id { get; set; }
        public string Origin { get; set; } 
        public string Destination { get; set; }
        public DateTime? Date { get; set; }
    }
}
