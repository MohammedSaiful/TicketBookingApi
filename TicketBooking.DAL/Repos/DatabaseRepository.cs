using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.DAL.Entities;

namespace TicketBooking.DAL.Repos
{
    internal class DatabaseRepository
    {
        internal readonly TicketBookingDBContext _db;
        internal DatabaseRepository() 
        {
            _db = new TicketBookingDBContext();
        }
    }
}
