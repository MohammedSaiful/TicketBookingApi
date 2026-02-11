using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.User;
using TicketBooking.BLL.Interfaces;
using TicketBooking.DAL;
using TicketBooking.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using TicketBooking.BLL.DTOs.Authentication;


namespace TicketBooking.BLL.Services
{
    public class AuthService : IAuth
    {
        private readonly DataAccessFactory _factory;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthService(DataAccessFactory factory, IMapper mapper, IJwtService jwtService)
        {
            _factory = factory;
            _mapper = mapper;
            _jwtService = jwtService;
            _passwordHasher = new PasswordHasher<User>();
        }
        public async Task<bool> RegisterAsync(UserRegisterDTO dto)
        {
            var entity = _mapper.Map<User>(dto);
            entity.Password = _passwordHasher.HashPassword(entity, dto.Password);
            return await _factory.UserData().CreateAsync(entity);
        }

        public async Task<AuthResponseDTO?> LoginAsync(UserLoginDTO dto)
        {
            var user = (await _factory.UserData().GetAllAsync())
                .FirstOrDefault(u => u.Email == dto.Email);

            if (user == null) return null;
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            var token = _jwtService.GenerateToken(user.Id, user.Email);

            return new AuthResponseDTO
            {
                Token = token,
                User = _mapper.Map<UserDTO>(user)

            };
        }
    }
}
