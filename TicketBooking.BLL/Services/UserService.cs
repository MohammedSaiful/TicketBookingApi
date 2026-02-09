using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.User;
using TicketBooking.BLL.Interfaces;
using TicketBooking.DAL;

namespace TicketBooking.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly DataAccessFactory _factory;
        private readonly IMapper _mapper;

        public UserService(DataAccessFactory factory, IMapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }

        public async Task<UserDTO?> GetAsync(int id)
        {
            var user = await _factory.UserData().GetAsync(id);
            return user == null ? null : _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var users = await _factory.UserData().GetAllAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<bool> RegisterAsync(UserRegisterDTO dto)
        {
            var entity = _mapper.Map<TicketBooking.DAL.Entities.User>(dto);
            return await _factory.UserData().CreateAsync(entity);
        }

        public async Task<UserDTO?> LoginAsync(UserLoginDTO dto)
        {
            var user = (await _factory.UserData().GetAllAsync())
                .FirstOrDefault(u => u.Email == dto.Email && u.Password == dto.Password);

            return user == null ? null : _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> UpdateAsync(int id, UserRegisterDTO dto)
        {
            var user = await _factory.UserData().GetAsync(id);
            if (user == null) return false;

            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.Password = dto.Password;

            return await _factory.UserData().UpdateAsync(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _factory.UserData().DeleteAsync(id);
        }
    }
}
