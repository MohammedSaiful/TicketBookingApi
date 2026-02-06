using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.DAL.Entities;
using TicketBooking.DAL.Interfaces;

namespace TicketBooking.DAL.Repos
{
    internal class RecommendationRepository : DatabaseRepository, IRecommendationFeature
    {
        public Task<List<Vehicle>> GetPopularVehiclesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Route>> GetTopRoutesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
