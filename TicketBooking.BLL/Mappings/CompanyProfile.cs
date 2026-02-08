using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Company;
using TicketBooking.DAL.Entities;

namespace TicketBooking.BLL.Mappings
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyCreateDTO, Company>();
            CreateMap<Company, CompanyReadDTO>();
            CreateMap<Company, CompanyVehicleDTO>();
        }
    }
}
