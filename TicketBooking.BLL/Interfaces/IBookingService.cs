using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Booking;

namespace TicketBooking.BLL.Interfaces
{
    public interface IBookingService
    {
        Task<BookingReadDTO?> GetAsync(int id);
        Task<List<BookingReadDTO>> GetAllAsync();
        Task<List<BookingReadDTO>> GetByUserAsync(int userId);

        Task<BookingDetailsDTO?> GetDetailsAsync(int bookingId);

        Task<bool> CreateAsync(BookingCreateDTO dto);
        Task<bool> ChangeStatusAsync(ChangeBookingStatusDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
