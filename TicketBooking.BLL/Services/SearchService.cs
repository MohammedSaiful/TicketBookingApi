using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Search;
using TicketBooking.BLL.Interfaces;
using TicketBooking.DAL;

namespace TicketBooking.BLL.Services
{
    public class SearchService : ISearchService
    {
        private readonly DataAccessFactory _factory;
        private readonly IMapper _mapper;

        public SearchService(DataAccessFactory factory, IMapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }

        public async Task<List<SearchRouteDTO>> GetAllRoutesAsync()
        {
            var routes = await _factory.SearchData().GetAllAsync();
            return _mapper.Map<List<SearchRouteDTO>>(routes);
        }

        public async Task<List<VehicleDTO>> SearchAsync(string origin, string destination, DateTime? date)
        {
            var vehicles = await _factory.SearchData().SearchAsync(origin, destination, date);
            return _mapper.Map<List<VehicleDTO>>(vehicles);
        }

        public async Task<List<SearchRouteVehicleDTO>> SearchWithVehiclesAsync(string origin, string destination)
        {
            var routes = await _factory.SearchData().SearchWithVehiclesAsync(origin, destination);
            return _mapper.Map<List<SearchRouteVehicleDTO>>(routes);
        }

        public async Task<List<SearchRouteVehicleDTO>> SearchByDateWithVehicleAsync(DateTime date)
        {
            var routes = await _factory.SearchData().SearchByDateWithVehicleAsync(date);
            return _mapper.Map<List<SearchRouteVehicleDTO>>(routes);
        }
    }
}
