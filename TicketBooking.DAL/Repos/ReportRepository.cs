using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.DAL.Entities;
using TicketBooking.DAL.Interfaces;

namespace TicketBooking.DAL.Repos
{
    internal class ReportRepository : DatabaseRepository, IReportFeature
    {
        public Task<List<TopRouteResult>> GetTopRoutesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalRevenueAsync()
        {
            throw new NotImplementedException();
        }
    }
}
