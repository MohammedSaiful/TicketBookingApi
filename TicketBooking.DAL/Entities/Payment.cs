using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.DAL.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }
        [Required]
        public PaymentStatus Status { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        [StringLength(100)]
        public string TransactionId { get; set; }
        [StringLength(50)]
        public string Method { get; set; } // Cash, Card, Mobile Banking
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        public virtual Booking Booking { get; set; }
    }
}
