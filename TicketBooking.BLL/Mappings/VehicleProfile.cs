using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Company;
using TicketBooking.BLL.DTOs.Search;
using TicketBooking.BLL.DTOs.Vehicle;
using TicketBooking.DAL.Entities;

namespace TicketBooking.BLL.Mappings
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleCreateDTO, Vehicle>();

            CreateMap<Vehicle, VehicleDTO>()
                .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Company.Name));

            CreateMap<Vehicle, VehicleInfoDTO>()
                .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Company.Name));

            CreateMap<Vehicle, VehicleCompanyDTO>()
                .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Company.Name));

            CreateMap<Vehicle, VehicleRouteDTO>()
                .ForMember(d => d.Origin, o => o.MapFrom(s => s.Route.Origin))
                .ForMember(d => d.Destination, o => o.MapFrom(s => s.Route.Destination));
        }
    }
}
