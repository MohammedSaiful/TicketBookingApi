using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.DAL.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        [Required]
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalFare { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountPercent { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal NetFare { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual ICollection<BookingSeat> BookingSeats { get; set; }
        public Booking()
        {
            BookingSeats = new List<BookingSeat>();
        }
        public virtual Payment Payment { get; set; }
    }
}
