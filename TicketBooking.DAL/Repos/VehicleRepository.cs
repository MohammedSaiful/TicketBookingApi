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
    internal class VehicleRepository : DatabaseRepository, IVehicleFeature
    {
        // Create
        public async Task<bool> CreateAsync(Vehicle entity)
        {
            _db.Vehicles.Add(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        // Create vehicle and seats
        public async Task<Vehicle> CreateWithSeatsAsync(Vehicle vehicle, int seatCount)
        {
            
            // Add vehicle
            _db.Vehicles.Add(vehicle);
            await _db.SaveChangesAsync();

            // Add seats directly
            for (int i = 1; i <= seatCount; i++)
            {
                _db.Seats.Add(new Seat
                {
                    SeatNumber = i.ToString(),
                    VehicleId = vehicle.Id,
                    IsBooked = false
                });
            }

            // Save all seats
            await _db.SaveChangesAsync();

            return vehicle;
        }

        // Delete vehicle
        public async Task<bool> DeleteAsync(int id)
        {
            var vehicle = await _db.Vehicles.FindAsync(id);
            if (vehicle == null) return false;

            _db.Vehicles.Remove(vehicle);
            return await _db.SaveChangesAsync() > 0;
        }

        // Get all vehicles
        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await _db.Vehicles.ToListAsync();
        }

        // Get vehicle by id
        public async Task<Vehicle?> GetAsync(int id)
        {
            return await _db.Vehicles.FindAsync(id);
        }

        // Get available seats of a vehicle
        public async Task<List<Seat>> GetAvailableSeatsAsync(int vehicleId)
        {
            return await _db.Seats
                .Where(s => s.VehicleId == vehicleId && !s.IsBooked)
                .ToListAsync();
        }

        // Get vehicles with their company details
        public async Task<List<Vehicle>> GetWithCompanyAsync()
        {
            return await _db.Vehicles
                .Include(v => v.Company)
                .ToListAsync();
        }

        // Get vehicles with their route details
        public async Task<List<Vehicle>> GetWithRouteAsync()
        {
            return await _db.Vehicles
                .Include(v => v.Route)
                .ToListAsync();
        }

        // Get vehicles with their seats
        public async Task<List<Vehicle>> GetWithSeatsAsync()
        {
            return await _db.Vehicles
                .Include(v => v.Seats)
                .ToListAsync();
        }

        // Get vehicles by company
        public async Task<List<Vehicle>> GetByCompanyAsync(int companyId)
        {
            return await _db.Vehicles
                .Where(v => v.CompanyId == companyId)
                .ToListAsync();
        }

        // Get vehicles by route
        public async Task<List<Vehicle>> GetByRouteAsync(int routeId)
        {
            return await _db.Vehicles
                .Where(v => v.RouteId == routeId)
                .ToListAsync();
        }

        // Update vehicle details
        public async Task<bool> UpdateAsync(Vehicle entity)
        {
            var exist = await _db.Vehicles.FindAsync(entity.Id);
            if (exist == null) return false;

            _db.Entry(exist).CurrentValues.SetValues(entity);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
