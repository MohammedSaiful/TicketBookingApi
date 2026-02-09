using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Booking;
using TicketBooking.BLL.Interfaces;
using TicketBooking.DAL;
using TicketBooking.DAL.Entities;

namespace TicketBooking.BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly DataAccessFactory _factory;
        private readonly IMapper _mapper;

        public BookingService(DataAccessFactory factory, IMapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }

        // Get single booking
        public async Task<BookingReadDTO?> GetAsync(int id)
        {
            var booking = await _factory.BookingData().GetAsync(id);

            if (booking == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<BookingReadDTO>(booking);
            }
        }

        // Get all bookings
        public async Task<List<BookingReadDTO>> GetAllAsync()
        {
            var bookings = await _factory.BookingData().GetAllAsync();
            return _mapper.Map<List<BookingReadDTO>>(bookings);
        }

        // Get bookings by user
        public async Task<List<BookingReadDTO>> GetByUserAsync(int userId)
        {
            var bookings = await _factory.BookingData().GetByUserAsync(userId);
            return _mapper.Map<List<BookingReadDTO>>(bookings);
        }

        // Get booking with seats/details
        public async Task<BookingDetailsDTO?> GetDetailsAsync(int bookingId)
        {
            var booking = await _factory.BookingData().GetWithSeatsAsync(bookingId);

            if (booking == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<BookingDetailsDTO>(booking);
            }
        }

        // Create booking with seats
        public async Task<bool> CreateAsync(BookingCreateDTO dto)
        {
            var booking = _mapper.Map<Booking>(dto);

            booking.BookingDate = DateTime.Now;
            booking.Status = BookingStatus.Pending;

            var created = await _factory.BookingData()
                .CreateBookingWithSeatsAsync(booking, dto.SeatIds);

            return created != null;
        }

        // Change booking status
        public async Task<bool> ChangeStatusAsync(ChangeBookingStatusDTO dto)
        {
            if (!Enum.TryParse<BookingStatus>(dto.Status, true, out var status))
                return false;

            return await _factory.BookingData()
                .ChangeStatusAsync(dto.BookingId, status);
        }

        // Delete booking
        public async Task<bool> DeleteAsync(int id)
        {
            return await _factory.BookingData().DeleteAsync(id);
        }
    }
}
