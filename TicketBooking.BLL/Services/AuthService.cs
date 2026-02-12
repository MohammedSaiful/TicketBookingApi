using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Authentication;
using TicketBooking.BLL.DTOs.User;
using TicketBooking.BLL.Interfaces;
using TicketBooking.DAL;
using TicketBooking.DAL.Entities;


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

        // Register a new user
        public async Task<bool> RegisterAsync(UserRegisterDTO dto)
        {
            var entity = _mapper.Map<User>(dto);
            entity.Password = _passwordHasher.HashPassword(entity, dto.Password);
            return await _factory.UserData().CreateAsync(entity);
        }

        // Login user and generate JWT token
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

            var access = _jwtService.GenerateToken(user.Id, user.Email, user.Role.ToString());
            var refresh = _jwtService.GenerateRefreshToken(user.Id);

            await _factory.RefreshTokenData().CreateAsync(refresh);

            return new AuthResponseDTO
            {
                User = _mapper.Map<UserDTO>(user),
                Token = access,
                RefreshToken = refresh.ReToken
            };
        }

        // Refresh JWT token using refresh token
        public async Task<AuthResponseDTO?> RefreshTokenAsync(string refreshToken)
        {
            var stored = await _factory.RefreshTokenData().GetByTokenAsync(refreshToken);

            if (stored == null || stored.Expires < DateTime.UtcNow)
                return null;


            // 🔹 rotate refresh TOKEN VALUE
            stored.ReToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            stored.Created = DateTime.UtcNow;

            await _factory.RefreshTokenData().UpdateAsync(stored);

            var user = stored.User;

            var newAccess = _jwtService.GenerateToken(user.Id, user.Email, user.Role.ToString());

            return new AuthResponseDTO
            {
                User = _mapper.Map<UserDTO>(user),
                Token = newAccess,
                RefreshToken = stored.ReToken
            };
        }
    }
}
