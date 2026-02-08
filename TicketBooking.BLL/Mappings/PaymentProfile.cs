using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Payment;
using TicketBooking.DAL.Entities;

namespace TicketBooking.BLL.Mappings
{
    public class PaymentProfile:Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentCreateDTO, Payment>();

            CreateMap<Payment, PaymentReadDTO>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));
        }
    }
}
