using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.DAL.Entities
{
    public class Seat
    {
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string SeatNumber { get; set; }

        public bool IsBooked { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public virtual ICollection<BookingSeat> BookingSeats { get; set; }

        public Seat() {
        
            BookingSeats = new List<BookingSeat>();
        }
    }
}
