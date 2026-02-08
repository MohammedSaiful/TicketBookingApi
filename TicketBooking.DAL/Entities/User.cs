using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(256)]
        public string Password { get; set; }
        [Required]
        [StringLength(20)]
        public UserRole Role { get; set; } = UserRole.Customer;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Booking> Bookings { get; set; }
        public User() { 
        
            Bookings = new List<Booking>();
        }
    }
}
