using Microsoft.EntityFrameworkCore;
using TicketBooking.BLL.Mappings;
using TicketBooking.DAL.Entities;
using TicketBooking.DAL;
using AutoMapper;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// registration the database context
builder.Services.AddDbContext<TicketBookingDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//register automapper
builder.Services.AddAutoMapper(
    typeof(BookingProfile).Assembly,
    typeof(CompanyProfile).Assembly,
    typeof(PaymentProfile).Assembly,
    typeof(RecommendationProfile).Assembly,
    typeof(ReportProfile).Assembly,
    typeof(SearchProfile).Assembly,
    typeof(UserProfile).Assembly,
    typeof(VehicleProfile).Assembly
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
