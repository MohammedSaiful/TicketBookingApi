using AutoMapper;
using TicketBooking.BLL.DTOs.Booking;
using TicketBooking.BLL.DTOs.Payment;
using TicketBooking.BLL.DTOs.Recommendation;
using TicketBooking.BLL.DTOs.Report;
using TicketBooking.BLL.DTOs.Search;
using TicketBooking.BLL.DTOs.User;
using TicketBooking.BLL.DTOs.Vehicle;
using TicketBooking.DAL.Entities;

namespace TicketBooking.BLL
{
    public class AllMappings
    {
        //static MapperConfiguration config = new MapperConfiguration(cfg =>
        //{
        //    // Booking Mappings
        //    cfg.CreateMap<BookingCreateDTO, Booking>();
        //    cfg.CreateMap<Booking, BookingReadDTO>();

        //    cfg.CreateMap<BookingSeat, SeatDTO>()
        //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Seat.Id))
        //    .ForMember(dest => dest.SeatNumber, opt => opt.MapFrom(src => src.Seat.SeatNumber));

        //    cfg.CreateMap<Booking, BookingDetailsDTO>()
        //    .ForMember(dest => dest.SeatNumbers,
        //    opt => opt.MapFrom(src => src.BookingSeats));


        //    //payment mappings
        //    cfg.CreateMap<PaymentCreateDTO, Payment>();
        //    cfg.CreateMap<Payment, PaymentReadDTO>();


        //    // Recommendation Mappings
        //    cfg.CreateMap<Route, RecommendedRouteDTO>();
        //    cfg.CreateMap<Vehicle, PopularVehicleDTO>();


        //    // Report Mappings
        //    cfg.CreateMap<TopRouteResult, TopRouteDTO>();


        //    // Search Mappings
        //    cfg.CreateMap<Route, SearchRouteDTO>();
        //    cfg.CreateMap<Route, SearchRouteVehicleDTO>();

        //    cfg.CreateMap<Vehicle, VehicleDTO>()
        //    .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));


        //    // User Mappings
        //    cfg.CreateMap<UserRegisterDTO, User>();
        //    cfg.CreateMap<User, UserDTO>();

        //    // Vehicle Mappings
        //    cfg.CreateMap<VehicleCreateDTO, Vehicle>();

        //    cfg.CreateMap<Vehicle, VehicleCompanyDTO>()
        //    .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));

        //    cfg.CreateMap<Vehicle, VehicleRouteDTO>()
        //    .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src.Route.Origin))
        //    .ForMember(dest => dest.Destination, opt => opt.MapFrom(src => src.Route.Destination));
        //});

        //public static Mapper GetMapper()
        //{
        //    return new Mapper(config);
        //}
    }
}
