using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Search;
using TicketBooking.DAL.Entities;

namespace TicketBooking.BLL.Mappings
{
    public class SearchProfile : Profile
    {
        public SearchProfile()
        {
            CreateMap<Route, SearchRouteDTO>();

            CreateMap<Route, SearchRouteVehicleDTO>();

            CreateMap<Vehicle, VehicleDTO>()
                .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Company.Name));
        }
    }
}
