using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Booking;
using TicketBooking.BLL.DTOs.Vehicle;
using TicketBooking.BLL.Interfaces;
using TicketBooking.DAL;

namespace TicketBooking.BLL.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly DataAccessFactory _factory;
        private readonly IMapper _mapper;

        public VehicleService(DataAccessFactory factory, IMapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }

        public async Task<List<VehicleCompanyDTO>> GetAllAsync()
        {
            var vehicles = await _factory.VehicleData().GetWithCompanyAsync();
            return _mapper.Map<List<VehicleCompanyDTO>>(vehicles);
        }

        public async Task<VehicleCompanyDTO?> GetAsync(int id)
        {
            var vehicle = await _factory.VehicleData().GetAsync(id);
            return vehicle == null ? null : _mapper.Map<VehicleCompanyDTO>(vehicle);
        }

        public async Task<List<VehicleCompanyDTO>> GetByCompanyAsync(int companyId)
        {
            var vehicles = await _factory.VehicleData().GetByCompanyAsync(companyId);
            return _mapper.Map<List<VehicleCompanyDTO>>(vehicles);
        }

        public async Task<List<VehicleRouteDTO>> GetByRouteAsync(int routeId)
        {
            var vehicles = await _factory.VehicleData().GetByRouteAsync(routeId);
            return _mapper.Map<List<VehicleRouteDTO>>(vehicles);
        }

        public async Task<List<SeatDTO>> GetAvailableSeatsAsync(int vehicleId)
        {
            var seats = await _factory.VehicleData().GetAvailableSeatsAsync(vehicleId);
            return _mapper.Map<List<SeatDTO>>(seats);
        }

        public async Task<bool> CreateAsync(VehicleCreateDTO dto)
        {
            var vehicle = _mapper.Map<TicketBooking.DAL.Entities.Vehicle>(dto);
            await _factory.VehicleData().CreateWithSeatsAsync(vehicle, dto.SeatCount);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _factory.VehicleData().DeleteAsync(id);
        }
    }
}
