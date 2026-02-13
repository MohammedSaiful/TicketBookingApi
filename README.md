# TicketBookingApi
The Ticket Booking API is a secure backend system built with ASP.NET Core.

## Technical Stack
* Framework: .NET 8 / ASP.NET Core Web API

* Database: SQL Server

* ORM: Entity Framework Core (Database First/Code First)

* Security: JWT Authentication with Refresh Token Rotation

* Mapping: AutoMapper (DTO Pattern)

* Patterns: Repository Pattern, Factory Pattern, Dependency Injection

## Architecture Overview
The project is divided into three distinct layers to ensure separation of concerns:

* Presentation Layer (API): Lean controllers handling HTTP requests and status codes.

* Business Logic Layer (BLL): The core engine. Handles DTO mapping, password hashing, and complex business rules (e.g., seat availability).

* Data Access Layer (DAL): Manages database interactions using the Repository pattern and a Centralized Data Factory.

## Key Features
### Security & Identity
* Secure Auth: Password hashing using PasswordHasher<User>.

* Token Management: Dual-token system (Access + Refresh Tokens) to balance security and user experience.

* Role-Based Access: Configured for Admin/User authorization.

## Booking Engine
* Seat Selection: Real-time checking of available seats for specific vehicles.

* Status Workflow: Automated status transitions (Pending → Paid → Cancelled).

* Search Engine: Advanced filtering by Origin, Destination, and Date.

## Business Intelligence
* Dashboard Reports: Aggregated data for total revenue and booking trends.

* Recommendations: Logic to identify top-performing routes and popular vehicles.

## Project Structure
```text
TicketBooking
|
|── TicketBooking.API
|   |── Controllers
|   |   |── AuthController.cs
|   |   |── BookingController.cs
|   |   |── CompanyController.cs
|   |   |── PaymentController.cs
|   |   |── RecommendationController.cs
|   |   |── ReportController.cs
|   |   |── SearchController.cs
|   |   |── UserController.cs
|   |   └── VehicleController.cs
|   |── Program.cs
|   └── appsettings.json
|
|── TicketBooking.BLL
|   |── DTOs
|   |   |── Authentication
|   |   |   |── AuthResponseDTO.cs
|   |   |   └── RefreshRequestDTO.cs
|   |   |── Booking
|   |   |   |── BookingCreateDTO.cs
|   |   |   |── BookingDetailsDTO.cs
|   |   |   |── BookingReadDTO.cs
|   |   |   |── ChangeBookingStatusDTO.cs
|   |   |   └── SeatDTO.cs
|   |   |── Company
|   |   |   |── CompanyCreateDTO.cs
|   |   |   |── CompanyReadDTO.cs
|   |   |   |── CompanyVehicleDTO.cs
|   |   |   └── VehicleInfoDTO.cs
|   |   |── Payment
|   |   |   |── PaymentCreateDTO.cs
|   |   |   └── PaymentReadDTO.cs
|   |   |── Recommendation
|   |   |   |── PopularVehicleDTO.cs
|   |   |   └── RecommendedRouteDTO.cs
|   |   |── Report
|   |   |   |── DashboardReportDTO.cs
|   |   |   |── RevenueReportDTO.cs
|   |   |   └── TopRouteDTO.cs
|   |   |── Search
|   |   |   |── SearchRouteDTO.cs
|   |   |   |── SearchRouteVehicleDTO.cs
|   |   |   └── VehicleDTO.cs
|   |   |── User
|   |   |   |── UserDTO.cs
|   |   |   |── UserLoginDTO.cs
|   |   |   |── UserRegisterDTO.cs
|   |   |   └── UserRoleDTO.cs
|   |   └── Vehicle
|   |       |── VehicleCompanyDTO.cs
|   |       |── VehicleCreateDTO.cs
|   |       |── VehicleDetailsDTO.cs
|   |       |── VehicleReadDTO.cs
|   |       └── VehicleRouteDTO.cs
|   |── Interfaces
|   |   |── IAuth.cs
|   |   |── IBookingService.cs
|   |   |── ICompanyService.cs
|   |   |── IJwtService.cs
|   |   |── IPaymentService.cs
|   |   |── IRecommendationService.cs
|   |   |── IReportService.cs
|   |   |── ISearchService.cs
|   |   |── IUserService.cs
|   |   └── IVehicleService.cs
|   |── Mappings
|   |   |── BookingProfile.cs
|   |   |── CompanyProfile.cs
|   |   |── PaymentProfile.cs
|   |   |── RecommendationProfile.cs
|   |   |── ReportProfile.cs
|   |   |── SearchProfile.cs
|   |   |── UserProfile.cs
|   |   └── VehicleProfile.cs
|   └── Services
|       |── AuthService.cs
|       |── BookingService.cs
|       |── CompanyService.cs
|       |── JwtService.cs
|       |── PaymentService.cs
|       |── RecommendationService.cs
|       |── ReportService.cs
|       |── SearchService.cs
|       |── UserService.cs
|       └── VehicleService.cs
|
|── TicketBooking.DAL
|   |── Entities
|   |   |── Booking.cs
|   |   |── BookingSeat.cs
|   |   |── Company.cs
|   |   |── Enum.cs
|   |   |── Payment.cs
|   |   |── RefreshToken.cs
|   |   |── Route.cs
|   |   |── Seat.cs
|   |   |── TicketBookingDBContext.cs
|   |   |── TopRouteResult.cs
|   |   |── User.cs
|   |   └── Vehicle.cs
|   |── Interfaces
|   |   |── IBookingFeature.cs
|   |   |── ICompanyFeature.cs
|   |   |── IPaymentFeature.cs
|   |   |── IRecommendationFeature.cs
|   |   |── IRefreshTokenFeature.cs
|   |   |── IReportFeature.cs
|   |   |── IRepository.cs
|   |   |── ISearchFeature.cs
|   |   |── IUserFeature.cs
|   |   └── IVehicleFeature.cs
|   |── Migrations
|   |── Repos
|   |   |── BookingRepository.cs
|   |   |── CompanyRepository.cs
|   |   |── PaymentRepository.cs
|   |   |── RecommendationRepository.cs
|   |   |── RefreshTokenRepository.cs
|   |   |── ReportRepository.cs
|   |   |── RouteRepository.cs
|   |   |── UserRepository.cs
|   |   └── VehicleRepository.cs
|   └── DataAccessFactory.cs

```