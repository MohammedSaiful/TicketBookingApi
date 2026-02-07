using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.BLL.DTOs.Booking
{
    public class BookingCreateDTO
    {
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public List<int> SeatIds { get; set; }

        public BookingCreateDTO() 
        {
            SeatIds = new List<int>();
        }
    }
}
