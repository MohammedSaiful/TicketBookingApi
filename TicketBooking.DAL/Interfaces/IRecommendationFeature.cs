using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.DAL.Entities;

namespace TicketBooking.DAL.Interfaces
{
    public interface IRecommendationFeature
    {
        Task<List<Route>> GetTopRoutesAsync();
        Task<List<Vehicle>> GetPopularVehiclesAsync();
    }
}
