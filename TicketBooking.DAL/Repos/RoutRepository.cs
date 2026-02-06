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
    internal class RoutRepository : DatabaseRepository, ISearchFeature
    {
        // Create a new Route
        public async Task<bool> CreateAsync(Route entity)
        {
            _db.Routes.Add(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        // Delete a Route by id
        public async Task<bool> DeleteAsync(int id)
        {
            var route = await _db.Routes.FindAsync(id);
            if (route == null) return false;

            _db.Routes.Remove(route);
            return await _db.SaveChangesAsync() > 0;
        }

        // Get all Routes
        public async Task<List<Route>> GetAllAsync()
        {
            return await _db.Routes.ToListAsync();
        }

        // Get a Route by id
        public async Task<Route?> GetAsync(int id)
        {
            return await _db.Routes.FindAsync(id);
        }

        // Update a Route
        public async Task<bool> UpdateAsync(Route entity)
        {
            var exist = await _db.Routes.FindAsync(entity.Id);
            if (exist == null) return false;

            _db.Entry(exist).CurrentValues.SetValues(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        // Search for Vehicles by origin, destination, optional date
        public async Task<List<Vehicle>> SearchAsync(string origin, string destination, DateTime? date)
        {
            var query = _db.Vehicles
                .Include(v => v.Route)
                .Include(v => v.Seats)
                .AsQueryable();

            if (!string.IsNullOrEmpty(origin))
                query = query.Where(v => v.Route.Origin == origin);

            if (!string.IsNullOrEmpty(destination))
                query = query.Where(v => v.Route.Destination == destination);

            if (date.HasValue)
                query = query.Where(v => v.DepartureTime.Date == date.Value.Date);

            return await query.ToListAsync();
        }

        // Get Routes with their Vehicles by origin and destination
        public async Task<List<Route>> SearchWithVehiclesAsync(string origin, string destination)
        {
            var routes = await _db.Routes
                .Include(r => r.Vehicles)
                .Where(r => r.Origin == origin && r.Destination == destination)
                .ToListAsync();

            return routes;
        }

        // Get Routes with Vehicles filtered by date
        public async Task<List<Route>> SearchByDateWithVehicleAsync(DateTime date)
        {
            var routes = await _db.Routes
                .Include(r => r.Vehicles.Where(v => v.DepartureTime.Date == date.Date))
                .ToListAsync();

            return routes;
        }
    }
}
