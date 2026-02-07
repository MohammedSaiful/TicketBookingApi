using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.BLL.DTOs.Booking
{
    public class BookingDetailsDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }
        public List<SeatDTO> SeatNumbers { get; set; }  // something

        public BookingDetailsDTO()
        {
            SeatNumbers = new List<SeatDTO>();
        }
    }
}
