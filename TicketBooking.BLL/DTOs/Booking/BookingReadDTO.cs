using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.BLL.DTOs.Booking
{
    public class BookingReadDTO
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }
    }
}
