using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.User;
using TicketBooking.DAL.Entities;

namespace TicketBooking.BLL.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterDTO, User>();

            CreateMap<User, UserDTO>();
        }
    }
}
