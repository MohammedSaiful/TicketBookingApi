using TicketBooking.DAL.Entities;
using TicketBooking.DAL.Interfaces;
using TicketBooking.DAL.Repos;

namespace TicketBooking.DAL
{
    public class DataAccessFactory
    {
        private readonly TicketBookingDBContext _db;
        public DataAccessFactory(TicketBookingDBContext db)
        {
            _db = db;
        }


        public ISearchFeature SearchData()
        {
            return new RouteRepository(_db);
        }

        public IBookingFeature BookingData()
        {
            return new BookingRepository(_db);
        }

        public IPaymentFeature PaymentData()
        {
            return new PaymentRepository(_db);
        }

        public IReportFeature ReportData()
        {
            return new ReportRepository(_db);
        }

        public IRecommendationFeature RecommendationData()
        {
            return new RecommendationRepository(_db);
        }

        public IUserFeature UserData()
        {
            return new UserRepository(_db);
        }

        public IVehicleFeature VehicleData()
        {
            return new VehicleRepository(_db);
        }

        public ICompanyFeature CompanyData()
        {
            return new CompanyRepository(_db);
        }
    }
}

