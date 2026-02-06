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

        // Creating a booking without seats
        public async Task<bool> CreateAsync(Booking obj)
        {
            _db.Bookings.Add(obj);
            return await _db.SaveChangesAsync() > 0;
        }

        // Get all bookings
        public async Task<List<Booking>> GetAllAsync()
        {
            return await _db.Bookings.ToListAsync();
        }


        // Get booking by id
        public async Task<Booking?> GetAsync(int id)
        {
            return await _db.Bookings.FindAsync(id);
        }

        // Update booking
        public async Task<bool> UpdateAsync(Booking obj)
        {
            var exist = await _db.Bookings.FindAsync(obj.Id);
            if (exist == null) return false;

            _db.Entry(exist).CurrentValues.SetValues(obj);
            return await _db.SaveChangesAsync() > 0;
        }


        // Delete booking
        public async Task<bool> DeleteAsync(int id)
        {
            var booking = await _db.Bookings.FindAsync(id);
            if (booking == null) return false;

            _db.Bookings.Remove(booking);
            return await _db.SaveChangesAsync() > 0;
        }


        // Get all bookings with seats
        public async Task<List<Booking>> GetAllWithSeatsAsync()
        {
            return await _db.Bookings
                .Include(b => b.BookingSeats)
                    .ThenInclude(bs => bs.Seat)
                .ToListAsync();
        }

        // Get bookings by user with seats
        public async Task<List<Booking>> GetByUserAsync(int userId)
        {
            return await _db.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.BookingSeats)
                    .ThenInclude(bs => bs.Seat)
                .ToListAsync();



            //var bookings = await (from b in _db.Bookings where b.UserId == userId select b).ToListAsync(); 

            //var bookingIds = bookings.Select(b => b.Id).ToList();
            //var bookingSeats = await (from bs in _db.BookingSeats where bookingIds.Contains(bs.BookingId) select bs).ToListAsync(); 

            //var seatIds = bookingSeats.Select(bs => bs.SeatId).ToList(); 
            //var seats = await (from s in _db.Seats where seatIds.Contains(s.Id) select s).ToListAsync();
        }

        // Get booking with seats
        public async Task<Booking?> GetWithSeatsAsync(int bookingId)
        {
            return await _db.Bookings
                .Include(b => b.BookingSeats)
                    .ThenInclude(bs => bs.Seat)
                .FirstOrDefaultAsync(b => b.Id == bookingId);
        }


        // Change booking status
        public async Task<bool> ChangeStatusAsync(int bookingId, BookingStatus status)
        {
            var booking = await _db.Bookings.FindAsync(bookingId);
            if (booking == null) return false;

            booking.Status = status;
            return await _db.SaveChangesAsync() > 0;
        }


        // Create booking with seats 
        public async Task<Booking> CreateBookingWithSeatsAsync(Booking booking, List<int> seatIds)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                booking.BookingDate = DateTime.Now;
                booking.Status = BookingStatus.Pending;

                _db.Bookings.Add(booking);
                await _db.SaveChangesAsync();

                foreach (var seatId in seatIds)
                {
                    var seat = await _db.Seats.FirstOrDefaultAsync(s =>
                        s.Id == seatId &&
                        s.VehicleId == booking.VehicleId);

                    if (seat == null)
                        throw new Exception("Seat not found for this vehicle");

                    if (seat.IsBooked)
                        throw new Exception("Seat already booked");

                    seat.IsBooked = true;

                    _db.BookingSeats.Add(new BookingSeat
                    {
                        BookingId = booking.Id,
                        SeatId = seatId
                    });
                }

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();

                return booking;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }



    }
}
