using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketBooking.DAL.Entities;
using TicketBooking.DAL.Interfaces;

namespace TicketBooking.DAL.Repos
{
    internal class BookingRepository : DatabaseRepository, IBookingFeature
    {
        public Task<bool> ChangeStatusAsync(int bookingId, BookingStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> CreateAsync(Booking entity)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> CreateBookingWithSeatsAsync(Booking booking, List<int> seatIds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>> GetAllWithSeatsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Booking?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>> GetByUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Booking?> GetWithSeatsAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Booking entity)
        {
            throw new NotImplementedException();
        }
    }
}
