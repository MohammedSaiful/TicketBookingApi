using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.DAL.Entities;

namespace TicketBooking.DAL.Interfaces
{
    public interface IRefreshTokenFeature
    {
        Task CreateAsync(RefreshToken token);

        Task<RefreshToken?> GetByTokenAsync(string token);

        Task UpdateAsync(RefreshToken token);

        //Task RevokeAllForUserAsync(int userId);
    }
}
