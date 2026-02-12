using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.DAL.Entities;

namespace TicketBooking.BLL.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(int userId, string email, string role);
        RefreshToken GenerateRefreshToken(int userId);
    }
}
