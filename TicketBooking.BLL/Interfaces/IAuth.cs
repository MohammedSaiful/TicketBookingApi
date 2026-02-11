using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Authentication;
using TicketBooking.BLL.DTOs.User;

namespace TicketBooking.BLL.Interfaces
{
    public interface IAuth
    {
        Task<bool> RegisterAsync(UserRegisterDTO dto);
        Task<AuthResponseDTO?> LoginAsync(UserLoginDTO dto);
    }
}
