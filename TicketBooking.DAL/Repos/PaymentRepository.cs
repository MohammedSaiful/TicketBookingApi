using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.DAL.Entities;
using TicketBooking.DAL.Interfaces;

namespace TicketBooking.DAL.Repos
{
    internal class PaymentRepository : DatabaseRepository, IPaymentFeature
    {
        public Task<Payment> CreateAsync(Payment entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Payment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Payment?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Payment?> GetByBookingAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalRevenueAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Payment entity)
        {
            throw new NotImplementedException();
        }
    }
}
