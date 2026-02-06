using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.DAL.Entities;
using TicketBooking.DAL.Interfaces;

namespace TicketBooking.DAL.Repos
{
    internal class CompanyRepository : DatabaseRepository, ICompanyFeature
    {
        public Task<Company> CreateAsync(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Company?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Company?> GetWithVehiclesAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> VehicleCountAsync(int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
