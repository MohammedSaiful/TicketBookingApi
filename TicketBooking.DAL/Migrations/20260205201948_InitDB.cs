using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketBooking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseFare = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    TotalFare = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    NetFare = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingSeat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSeat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingSeat_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingSeat_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    { 1, new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6699), "rahim@gmail.com", "Rahim", "Rahim@123", "Customer" },
                    { 2, new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6700), "karim@gmail.com", "Karim", "Karim@123", "Customer" },
                    { 3, new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6701), "salma@gmail.com", "Salma", "Salma@123", "Customer" },
                    { 4, new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6703), "rita@gmail.com", "Rita", "Rita@123", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "BaseFare", "CompanyId", "DepartureTime", "RouteId", "TotalSeats", "Type" },
                values: new object[,]
                {
                    { 1, 1200m, 1, new DateTime(2026, 2, 6, 10, 0, 0, 0, DateTimeKind.Local), 1, 40, "Bus" },
                    { 2, 1100m, 2, new DateTime(2026, 2, 6, 14, 0, 0, 0, DateTimeKind.Local), 2, 40, "Bus" },
                    { 3, 1000m, 3, new DateTime(2026, 2, 6, 16, 0, 0, 0, DateTimeKind.Local), 3, 40, "Bus" },
                    { 4, 1300m, 4, new DateTime(2026, 2, 6, 18, 0, 0, 0, DateTimeKind.Local), 4, 40, "Bus" }
                });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "BookingDate", "CreatedAt", "DiscountPercent", "NetFare", "Status", "TotalFare", "UserId", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6722), new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6723), 0m, 2400m, "Confirmed", 2400m, 1, 1 },
                    { 2, new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6725), new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6726), 0m, 1200m, "Pending", 1200m, 2, 1 },
                    { 3, new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6727), new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6728), 10m, 1980m, "Confirmed", 2200m, 3, 2 },
                    { 4, new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6730), new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6731), 0m, 1100m, "Cancelled", 1100m, 4, 2 }
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
                    { 1, 2400m, 1, "Card", new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6763), "Paid", "TXN1001" },
                    { 2, 1200m, 2, "Cash", new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6765), "Failed", "TXN1002" },
                    { 3, 1980m, 3, "Mobile Banking", new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6767), "Paid", "TXN1003" },
                    { 4, 1100m, 4, "Card", new DateTime(2026, 2, 5, 20, 19, 47, 772, DateTimeKind.Utc).AddTicks(6768), "Refunded", "TXN1004" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_VehicleId",
                table: "Booking",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSeat_BookingId_SeatId",
                table: "BookingSeat",
                columns: new[] { "BookingId", "SeatId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingSeat_SeatId",
                table: "BookingSeat",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_BookingId",
                table: "Payment",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_VehicleId",
                table: "Seat",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CompanyId",
                table: "Vehicle",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_RouteId",
                table: "Vehicle",
                column: "RouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingSeat");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Route");
        }
    }
}
