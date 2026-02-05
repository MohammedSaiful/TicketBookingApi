using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.DAL.Entities
{
    public class TopRouteResult
    {
        public virtual Route Route { get; set; }
        public int BookingCount { get; set; }
    }
}
