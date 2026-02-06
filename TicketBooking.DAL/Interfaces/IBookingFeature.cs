using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.DAL.Entities;

namespace TicketBooking.DAL.Interfaces
{
    public interface IBookingFeature: IRepository<Booking>
    {
        Task<List<Booking>> GetByUserAsync(int userId);
        Task<Booking?> GetWithSeatsAsync(int bookingId);
        Task<List<Booking>> GetAllWithSeatsAsync();
        Task<bool> ChangeStatusAsync(int bookingId, BookingStatus status);
        Task<Booking> CreateBookingWithSeatsAsync(Booking booking, List<int> seatIds);
    }
}
