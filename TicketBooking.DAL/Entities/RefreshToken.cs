using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.DAL.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string ReToken { get; set; } = string.Empty;
        public int UserId { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; } = null!;
    }
}
