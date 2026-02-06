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
    internal class CompanyRepository : DatabaseRepository, ICompanyFeature
    {
        // Create a new company
        public async Task<bool> CreateAsync(Company entity)
        {
            _db.Companies.Add(entity);
            return await _db.SaveChangesAsync()>0;
        }

        // Get company by Id
        public async Task<Company?> GetAsync(int id)
        {
            return await _db.Companies.FindAsync(id);
        }

        // Get all companies
        public async Task<List<Company>> GetAllAsync()
        {
            return await _db.Companies.ToListAsync();
        }

        // Update company
        public async Task<bool> UpdateAsync(Company entity)
        {
            var exist = await _db.Companies.FindAsync(entity.Id);
            if (exist == null) return false;

            _db.Entry(exist).CurrentValues.SetValues(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        // Delete company
        public async Task<bool> DeleteAsync(int id)
        {
            var exist = await _db.Companies.FindAsync(id);
            if (exist == null) return false;

            _db.Companies.Remove(exist);
            return await _db.SaveChangesAsync() > 0;
        }

        // Get company with all vehicles
        public async Task<Company?> GetWithVehiclesAsync(int companyId)
        {
            return await _db.Companies
                .Include(c => c.Vehicles)
                //.ThenInclude(v => v.Seats) // optional if you want seats too
                .FirstOrDefaultAsync(c => c.Id == companyId);
        }

        // Get total number of vehicles for a company
        public async Task<int> VehicleCountAsync(int companyId)
        {
            return await _db.Vehicles
                .Where(v => v.CompanyId == companyId)
                .CountAsync();
        }
    }
}
