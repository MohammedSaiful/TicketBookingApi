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
    internal class UserRepository : IUserFeature
    {
        private readonly TicketBookingDBContext _db;
        public UserRepository(TicketBookingDBContext db)
        {
            _db = db;
        }

        // Create a new User
        public async Task<bool> CreateAsync(User entity)
        {
            _db.Users.Add(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        // Delete a User by id
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null) return false;

            _db.Users.Remove(user);
            return await _db.SaveChangesAsync() > 0;
        }

        // Get all users
        public async Task<List<User>> GetAllAsync()
        {
            return await _db.Users.ToListAsync();
        }

        // Get a single user by id
        public async Task<User?> GetAsync(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        // Update user details
        public async Task<bool> UpdateAsync(User entity)
        {
            var exist = await _db.Users.FindAsync(entity.Id);
            if (exist == null) return false;

            _db.Entry(exist).CurrentValues.SetValues(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        // Get a user along with all bookings
        public async Task<User?> GetWithBookingsAsync(int userId)
        {
            return await _db.Users
                .Include(u => u.Bookings)
                    .ThenInclude(b => b.BookingSeats)
                        .ThenInclude(bs => bs.Seat)
                .Include(u => u.Bookings)
                    .ThenInclude(b => b.Payment)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        
    }
}
