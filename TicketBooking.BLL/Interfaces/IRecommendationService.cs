using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Recommendation;

namespace TicketBooking.BLL.Interfaces
{
    public interface IRecommendationService
    {
        Task<List<RecommendedRouteDTO>> GetTopRoutesAsync();
        Task<List<PopularVehicleDTO>> GetPopularVehiclesAsync();
    }
}
