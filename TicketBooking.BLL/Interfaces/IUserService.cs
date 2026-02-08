using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.User;

namespace TicketBooking.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO?> GetAsync(int id);
        Task<List<UserDTO>> GetAllAsync();

        Task<bool> RegisterAsync(UserRegisterDTO dto);
        Task<UserDTO?> LoginAsync(UserLoginDTO dto);
        Task<bool> UpdateAsync(int id, UserRegisterDTO dto);
        Task<bool> DeleteAsync(int id);

    }
}
