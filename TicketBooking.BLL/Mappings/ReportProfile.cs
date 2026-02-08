using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Report;
using TicketBooking.DAL.Entities;

namespace TicketBooking.BLL.Mappings
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<TopRouteResult, TopRouteDTO>();
        }
    }
}
