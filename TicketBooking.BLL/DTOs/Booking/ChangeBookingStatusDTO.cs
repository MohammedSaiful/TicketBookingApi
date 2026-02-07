using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.BLL.DTOs.Booking
{
    public class ChangeBookingStatusDTO
    {
        public int BookingId { get; set; }
        public string Status { get; set; }
    }
}
