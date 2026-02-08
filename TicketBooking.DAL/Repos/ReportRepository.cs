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
    internal class ReportRepository : IReportFeature
    {

        private readonly TicketBookingDBContext _db;
        public ReportRepository(TicketBookingDBContext db)
        {
            _db = db;
        }

        // Get total number of bookings
        public async Task<int> GetTotalBookingsAsync()
        {
            return await _db.Bookings.CountAsync();
        }

        // Get total revenue from all payments
        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _db.Payments
                .Where(p => p.Status == PaymentStatus.Paid)
                .SumAsync(p => p.Amount);
        }

        // Get top routes with booking counts
        public async Task<List<TopRouteResult>> GetTopRoutesAsync()
        {
            var topRoutes = await _db.Bookings
                .Include(b => b.Vehicle)
                    .ThenInclude(v => v.Route)
                .GroupBy(b => b.Vehicle.Route)
                .Select(g => new TopRouteResult
                {
                    Route = g.Key,
                    BookingCount = g.Count()
                })
                .OrderByDescending(r => r.BookingCount)
                .Take(5)
                .ToListAsync();

            return topRoutes;
        }
    }
}
