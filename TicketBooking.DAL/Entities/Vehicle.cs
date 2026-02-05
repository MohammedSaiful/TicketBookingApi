using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.DAL.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }


        [Required]
        [StringLength(50)]
        public string Type { get; set; } // Bus / Train / Flight


        public DateTime DepartureTime { get; set; }


        [Column(TypeName = "decimal(10,2)")]
        public decimal BaseFare { get; set; }


        public int TotalSeats { get; set; }


        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }


        [ForeignKey("Route")]
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }


        public virtual ICollection<Seat> Seats { get; set; }

        public Vehicle() { 
        
            Seats = new List<Seat>();
        }
    }
}
