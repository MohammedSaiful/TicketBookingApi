using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketBooking.BLL.Interfaces;
using TicketBooking.BLL.Mappings;
using TicketBooking.BLL.Services;
using TicketBooking.DAL;
using TicketBooking.DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//JWT Authentication
var jwtkey = builder.Configuration["Jwt:Key"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
 {
     var key = Encoding.UTF8.GetBytes(jwtkey);
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,

         ValidIssuer = builder.Configuration["Jwt:Issuer"],
         ValidAudience = builder.Configuration["Jwt:Audience"],
         IssuerSigningKey = new SymmetricSecurityKey(key)
     };
 });
builder.Services.AddAuthorization(); // For role-based auth




// registration the database context
builder.Services.AddDbContext<TicketBookingDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// register DataAccessFactory
builder.Services.AddScoped<DataAccessFactory>();


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


// register services
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IRecommendationService, RecommendationService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IAuth, AuthService>();
builder.Services.AddScoped<IJwtService, JwtService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
