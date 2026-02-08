using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Recommendation;
using TicketBooking.DAL.Entities;

namespace TicketBooking.BLL.Mappings
{
    public class RecommendationProfile : Profile
    {
        public RecommendationProfile()
        {
            CreateMap<Route, RecommendedRouteDTO>();
            CreateMap<Vehicle, PopularVehicleDTO>();
        }
    }
}
