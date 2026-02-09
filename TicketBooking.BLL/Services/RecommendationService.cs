using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Recommendation;
using TicketBooking.BLL.Interfaces;
using TicketBooking.DAL;

namespace TicketBooking.BLL.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly DataAccessFactory _factory;
        private readonly IMapper _mapper;

        public RecommendationService(DataAccessFactory factory, IMapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }

        public async Task<List<RecommendedRouteDTO>> GetTopRoutesAsync()
        {
            var routes = await _factory.RecommendationData().GetTopRoutesAsync();
            return _mapper.Map<List<RecommendedRouteDTO>>(routes);
        }

        public async Task<List<PopularVehicleDTO>> GetPopularVehiclesAsync()
        {
            var vehicles = await _factory.RecommendationData().GetPopularVehiclesAsync();
            return _mapper.Map<List<PopularVehicleDTO>>(vehicles);
        }
    }
}
