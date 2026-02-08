using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.DAL.Entities;
using TicketBooking.DAL.Interfaces;

namespace TicketBooking.DAL.Repos
{
    internal class PaymentRepository : IPaymentFeature
    {
        private readonly TicketBookingDBContext _db;
        public PaymentRepository(TicketBookingDBContext db)
        {
            _db = db;
        }

        // Create a new payment
        public async Task<bool> CreateAsync(Payment entity)
        {
            _db.Payments.Add(entity);
            return await _db.SaveChangesAsync()>0;
        }

        // Get payment by Id
        public async Task<Payment?> GetAsync(int id)
        {
            return await _db.Payments.FindAsync(id);
        }

        // Get all payments
        public async Task<List<Payment>> GetAllAsync()
        {
            return await _db.Payments
                //.Include(p => p.Booking) // optional if i want booking details
                .ToListAsync();
        }

        // Update payment
        public async Task<bool> UpdateAsync(Payment entity)
        {
            var exist = await _db.Payments.FindAsync(entity.Id);
            if (exist == null) return false;

            _db.Entry(exist).CurrentValues.SetValues(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        // Delete payment
        public async Task<bool> DeleteAsync(int id)
        {
            var exist = await _db.Payments.FindAsync(id);
            if (exist == null) return false;

            _db.Payments.Remove(exist);
            return await _db.SaveChangesAsync() > 0;
        }

        // Get payment by booking
        public async Task<Payment?> GetByBookingAsync(int bookingId)
        {
            return await _db.Payments
                .SingleOrDefaultAsync(p => p.BookingId == bookingId);
        }

        // Get total revenue
        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _db.Payments
                .Where(p => p.Status == PaymentStatus.Paid)
                .SumAsync(p => p.Amount);
        }
    }
}
