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
    internal class RecommendationRepository : IRecommendationFeature
    {
        private readonly TicketBookingDBContext _db;
        public RecommendationRepository(TicketBookingDBContext db)
        {
            _db = db;
        }

        // Top routes based on number of bookings
        public async Task<List<Route>> GetTopRoutesAsync()
        {
            var topRoutes = await _db.Bookings
                .Include(b => b.Vehicle)
                    .ThenInclude(v => v.Route)
                .GroupBy(b => b.Vehicle.Route)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(5) // top 5 routes
                .ToListAsync();

            return topRoutes;
        }

        // Popular vehicles based on number of bookings
        public async Task<List<Vehicle>> GetPopularVehiclesAsync()
        {
            var popularVehicles = await _db.Bookings
                .Include(b => b.Vehicle)
                    .ThenInclude(v => v.Seats)
                .GroupBy(b => b.Vehicle)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(5) // top 5 vehicles
                .ToListAsync();

            return popularVehicles;
        }
    }
}
