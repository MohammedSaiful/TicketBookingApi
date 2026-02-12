using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketBooking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "GreenLine" },
                    { 2, "Shohagh" },
                    { 3, "Hanif" },
                    { 4, "Soudia" }
                });

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "Id", "Destination", "Origin" },
                values: new object[,]
                {
                    { 1, "Chittagong", "Dhaka" },
                    { 2, "Sylhet", "Dhaka" },
                    { 3, "Rajshahi", "Dhaka" },
                    { 4, "Sylhet", "Chittagong" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(477), "rahim@gmail.com", "Rahim", "Rahim@123", "Customer" },
                    { 2, new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(479), "karim@gmail.com", "Karim", "Karim@123", "Customer" },
                    { 3, new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(480), "salma@gmail.com", "Salma", "Salma@123", "Customer" },
                    { 4, new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(482), "rita@gmail.com", "Rita", "Rita@123", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "BaseFare", "CompanyId", "DepartureTime", "RouteId", "TotalSeats", "Type" },
                values: new object[,]
                {
                    { 1, 1200m, 1, new DateTime(2026, 2, 13, 10, 0, 0, 0, DateTimeKind.Local), 1, 40, "Bus" },
                    { 2, 1100m, 2, new DateTime(2026, 2, 13, 14, 0, 0, 0, DateTimeKind.Local), 2, 40, "Bus" },
                    { 3, 1000m, 3, new DateTime(2026, 2, 13, 16, 0, 0, 0, DateTimeKind.Local), 3, 40, "Bus" },
                    { 4, 1300m, 4, new DateTime(2026, 2, 13, 18, 0, 0, 0, DateTimeKind.Local), 4, 40, "Bus" }
                });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "BookingDate", "CreatedAt", "DiscountPercent", "NetFare", "Status", "TotalFare", "UserId", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(500), new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(502), 0m, 2400m, "Confirmed", 2400m, 1, 1 },
                    { 2, new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(504), new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(505), 0m, 1200m, "Pending", 1200m, 2, 1 },
                    { 3, new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(506), new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(507), 10m, 1980m, "Confirmed", 2200m, 3, 2 },
                    { 4, new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(509), new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(509), 0m, 1100m, "Cancelled", 1100m, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Seat",
                columns: new[] { "Id", "IsBooked", "SeatNumber", "VehicleId" },
                values: new object[,]
                {
                    { 1, false, "A1", 1 },
                    { 2, false, "A2", 1 },
                    { 3, false, "A3", 1 },
                    { 4, false, "A4", 1 },
                    { 5, false, "B1", 2 },
                    { 6, false, "B2", 2 },
                    { 7, false, "B3", 2 },
                    { 8, false, "B4", 2 }
                });

            migrationBuilder.InsertData(
                table: "BookingSeat",
                columns: new[] { "Id", "BookingId", "SeatId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "Id", "Amount", "BookingId", "Method", "PaymentDate", "Status", "TransactionId" },
                values: new object[,]
                {
                    { 1, 2400m, 1, "Card", new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(542), "Paid", "TXN1001" },
                    { 2, 1200m, 2, "Cash", new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(547), "Failed", "TXN1002" },
                    { 3, 1980m, 3, "Mobile Banking", new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(549), "Paid", "TXN1003" },
                    { 4, 1100m, 4, "Card", new DateTime(2026, 2, 12, 19, 30, 39, 357, DateTimeKind.Utc).AddTicks(550), "Refunded", "TXN1004" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookingSeat",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookingSeat",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookingSeat",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookingSeat",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
