using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.DAL.Entities
{
    public class TicketBookingDBContext : DbContext
    {

        // Parameterless constructor for EF Core design-time
        public TicketBookingDBContext()
        {
        }

        public TicketBookingDBContext(DbContextOptions<TicketBookingDBContext> options) 
            : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingSeat> BookingSeats { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Only configure if options not already set (so DI still works)
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=TicketBookingDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Route>().ToTable("Route");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<Seat>().ToTable("Seat");
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<BookingSeat>().ToTable("BookingSeat");
            modelBuilder.Entity<Payment>().ToTable("Payment");


            // Enum as string in DB 
            modelBuilder.Entity<Booking>()
            .Property(b => b.Status)
            .HasConversion<string>()
            .HasMaxLength(20);


            modelBuilder.Entity<Payment>()
            .Property(p => p.Status)
            .HasConversion<string>()
            .HasMaxLength(20);


            modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>()
            .HasMaxLength(20);


            //  Unique constraints
            // Ensure a seat can be booked only once per booking
            modelBuilder.Entity<BookingSeat>()
            .HasIndex(bs => new { bs.BookingId, bs.SeatId })
            .IsUnique();


            // Booking → Payment (one-to-one)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Payment)
                .WithOne(p => p.Booking)
                .HasForeignKey<Payment>(p => p.BookingId)
                .OnDelete(DeleteBehavior.Restrict); // prevent cascade issues

            // BookingSeat → Booking (many-to-one)
            modelBuilder.Entity<BookingSeat>()
                .HasOne(bs => bs.Booking)
                .WithMany(b => b.BookingSeats)
                .HasForeignKey(bs => bs.BookingId)
                .OnDelete(DeleteBehavior.Cascade); // deleting a booking deletes its seats

            // BookingSeat → Seat (many-to-one)
            modelBuilder.Entity<BookingSeat>()
                .HasOne(bs => bs.Seat)
                .WithMany(s => s.BookingSeats)
                .HasForeignKey(bs => bs.SeatId)
                .OnDelete(DeleteBehavior.Restrict); // prevent multiple cascade paths

            // Seat → Vehicle (many-to-one)
            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Vehicle)
                .WithMany(v => v.Seats)
                .HasForeignKey(s => s.VehicleId)
                .OnDelete(DeleteBehavior.Restrict); // restrict to avoid cascade conflicts

            // Vehicle → Company (many-to-one)
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Company)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(v => v.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Vehicle → Route (many-to-one)
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Route)
                .WithMany(r => r.Vehicles)
                .HasForeignKey(v => v.RouteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Booking → User (many-to-one)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Optional: configure decimal precision
            modelBuilder.Entity<Booking>()
                .Property(b => b.TotalFare)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Booking>()
                .Property(b => b.DiscountPercent)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Booking>()
                .Property(b => b.NetFare)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.BaseFare)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(10,2)");





            //  Seed Data 

            // Companies
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "GreenLine" },
                new Company { Id = 2, Name = "Shohagh" },
                new Company { Id = 3, Name = "Hanif" },
                new Company { Id = 4, Name = "Soudia" }
            );

            // Routes
            modelBuilder.Entity<Route>().HasData(
                new Route { Id = 1, Origin = "Dhaka", Destination = "Chittagong" },
                new Route { Id = 2, Origin = "Dhaka", Destination = "Sylhet" },
                new Route { Id = 3, Origin = "Dhaka", Destination = "Rajshahi" },
                new Route { Id = 4, Origin = "Chittagong", Destination = "Sylhet" }
            );

            // Vehicles
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, Type = "Bus", DepartureTime = DateTime.Today.AddHours(10), BaseFare = 1200, TotalSeats = 40, CompanyId = 1, RouteId = 1 },
                new Vehicle { Id = 2, Type = "Bus", DepartureTime = DateTime.Today.AddHours(14), BaseFare = 1100, TotalSeats = 40, CompanyId = 2, RouteId = 2 },
                new Vehicle { Id = 3, Type = "Bus", DepartureTime = DateTime.Today.AddHours(16), BaseFare = 1000, TotalSeats = 40, CompanyId = 3, RouteId = 3 },
                new Vehicle { Id = 4, Type = "Bus", DepartureTime = DateTime.Today.AddHours(18), BaseFare = 1300, TotalSeats = 40, CompanyId = 4, RouteId = 4 }
            );

            // Seats (4 seats per vehicle )
            modelBuilder.Entity<Seat>().HasData(
                // Vehicle 1
                new Seat { Id = 1, SeatNumber = "A1", VehicleId = 1, IsBooked = false },
                new Seat { Id = 2, SeatNumber = "A2", VehicleId = 1, IsBooked = false },
                new Seat { Id = 3, SeatNumber = "A3", VehicleId = 1, IsBooked = false },
                new Seat { Id = 4, SeatNumber = "A4", VehicleId = 1, IsBooked = false },

                // Vehicle 2
                new Seat { Id = 5, SeatNumber = "B1", VehicleId = 2, IsBooked = false },
                new Seat { Id = 6, SeatNumber = "B2", VehicleId = 2, IsBooked = false },
                new Seat { Id = 7, SeatNumber = "B3", VehicleId = 2, IsBooked = false },
                new Seat { Id = 8, SeatNumber = "B4", VehicleId = 2, IsBooked = false }
            );

            // Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FullName = "Rahim", Email = "rahim@gmail.com", Password = "Rahim@123", Role = UserRole.Customer, CreatedAt = DateTime.UtcNow },
                new User { Id = 2, FullName = "Karim", Email = "karim@gmail.com", Password = "Karim@123", Role = UserRole.Customer, CreatedAt = DateTime.UtcNow },
                new User { Id = 3, FullName = "Salma", Email = "salma@gmail.com", Password = "Salma@123", Role = UserRole.Customer, CreatedAt = DateTime.UtcNow },
                new User { Id = 4, FullName = "Rita", Email = "rita@gmail.com", Password = "Rita@123", Role = UserRole.Customer, CreatedAt = DateTime.UtcNow }
            );

            // Bookings
            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 1, UserId = 1, VehicleId = 1, Status = BookingStatus.Confirmed, BookingDate = DateTime.UtcNow, TotalFare = 2400, DiscountPercent = 0, NetFare = 2400, CreatedAt = DateTime.UtcNow },
                new Booking { Id = 2, UserId = 2, VehicleId = 1, Status = BookingStatus.Pending, BookingDate = DateTime.UtcNow, TotalFare = 1200, DiscountPercent = 0, NetFare = 1200, CreatedAt = DateTime.UtcNow },
                new Booking { Id = 3, UserId = 3, VehicleId = 2, Status = BookingStatus.Confirmed, BookingDate = DateTime.UtcNow, TotalFare = 2200, DiscountPercent = 10, NetFare = 1980, CreatedAt = DateTime.UtcNow },
                new Booking { Id = 4, UserId = 4, VehicleId = 2, Status = BookingStatus.Cancelled, BookingDate = DateTime.UtcNow, TotalFare = 1100, DiscountPercent = 0, NetFare = 1100, CreatedAt = DateTime.UtcNow }
            );

            // BookingSeats
            modelBuilder.Entity<BookingSeat>().HasData(
                new BookingSeat { Id = 1, BookingId = 1, SeatId = 1 },
                new BookingSeat { Id = 2, BookingId = 1, SeatId = 2 },
                new BookingSeat { Id = 3, BookingId = 2, SeatId = 3 },
                new BookingSeat { Id = 4, BookingId = 3, SeatId = 5 }
            );

            // Payments
            modelBuilder.Entity<Payment>().HasData(
                new Payment { Id = 1, BookingId = 1, Amount = 2400, Status = PaymentStatus.Paid, PaymentDate = DateTime.UtcNow, TransactionId = "TXN1001", Method = "Card" },
                new Payment { Id = 2, BookingId = 2, Amount = 1200, Status = PaymentStatus.Failed, PaymentDate = DateTime.UtcNow, TransactionId = "TXN1002", Method = "Cash" },
                new Payment { Id = 3, BookingId = 3, Amount = 1980, Status = PaymentStatus.Paid, PaymentDate = DateTime.UtcNow, TransactionId = "TXN1003", Method = "Mobile Banking" },
                new Payment { Id = 4, BookingId = 4, Amount = 1100, Status = PaymentStatus.Refunded, PaymentDate = DateTime.UtcNow, TransactionId = "TXN1004", Method = "Card" }
            );


        }
    }
}
