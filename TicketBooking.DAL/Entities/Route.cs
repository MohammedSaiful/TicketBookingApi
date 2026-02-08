using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.DAL.Entities
{
    public class Route
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Origin { get; set; }
        [Required]
        [StringLength(100)]
        public string Destination { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public Route() {       
            Vehicles = new List<Vehicle>();
        }
    }
}
