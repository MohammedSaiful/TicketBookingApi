using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.DAL.Entities;

namespace TicketBooking.DAL.Interfaces
{
    public interface IPaymentFeature : IRepository<Payment>
    {
        Task<Payment?> GetByBookingAsync(int bookingId);
        Task<decimal> GetTotalRevenueAsync();
    }
}
