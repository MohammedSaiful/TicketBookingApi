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
    internal class RefreshTokenRepository : IRefreshTokenFeature
    {
        private readonly TicketBookingDBContext _db;

        public RefreshTokenRepository(TicketBookingDBContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(RefreshToken token)
        {
            _db.RefreshTokens.Add(token);
            await _db.SaveChangesAsync();
        }

        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            return await _db.RefreshTokens
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.ReToken == token);
        }

        public async Task UpdateAsync(RefreshToken token)
        {
            _db.RefreshTokens.Update(token);
            await _db.SaveChangesAsync();
        }

        //public async Task RevokeAllForUserAsync(int userId)
        //{
        //    var tokens = await _db.RefreshTokens
        //        .Where(t => t.UserId == userId )
        //        .ToListAsync();

        //    foreach (var t in tokens)
        //        t.Revoked = true;

        //    await _db.SaveChangesAsync();
        //}
    }
}
