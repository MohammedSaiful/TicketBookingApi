using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Booking;
using TicketBooking.DAL.Entities;

namespace TicketBooking.BLL.Mappings
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingCreateDTO, Booking>();

            CreateMap<Booking, BookingReadDTO>();

            CreateMap<Seat, SeatDTO>();

            CreateMap<BookingSeat, SeatDTO>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Seat.Id))
                .ForMember(d => d.SeatNumber, o => o.MapFrom(s => s.Seat.SeatNumber));

            CreateMap<Booking, BookingDetailsDTO>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()))
                .ForMember(d => d.SeatNumbers, o => o.MapFrom(s => s.BookingSeats));
        }
    }
}
