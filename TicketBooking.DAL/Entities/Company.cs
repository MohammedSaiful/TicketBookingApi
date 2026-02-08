using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.DAL.Entities
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public Company() {
            Vehicles = new List<Vehicle>();
        }
    }
}
