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
        public Task<Route> CreateAsync(Route entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Route>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Route?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vehicle>> SearchAsync(string origin, string destination, DateTime? date)
        {
            throw new NotImplementedException();
        }

        public Task<List<Route>> SearchByDateWithVehicleAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<List<Route>> SearchWithVehiclesAsync(string origin, string destination)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Route entity)
        {
            throw new NotImplementedException();
        }
    }
}
