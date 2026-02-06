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
        public Task<Vehicle> CreateAsync(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> CreateWithSeatsAsync(Vehicle vehicle, int seatCount)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vehicle>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Seat>> GetAvailableSeatsAsync(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vehicle>> GetByCompanyAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vehicle>> GetByRouteAsync(int routeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vehicle>> GetWithCompanyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Vehicle>> GetWithRouteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Vehicle>> GetWithSeatsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Vehicle entity)
        {
            throw new NotImplementedException();
        }
    }
}
