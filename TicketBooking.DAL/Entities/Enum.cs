using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.DAL.Entities
{
    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }
    public enum PaymentStatus
    {
        Paid,
        Failed,
        Refunded,
        Pending
    }
    public enum UserRole
    {
        Admin,
        Customer
    }
}
