using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.DAL.Entities;

namespace TicketBooking.DAL.Interfaces
{
    public interface IVehicleFeature : IRepository<Vehicle>
    {
        Task<List<Seat>> GetAvailableSeatsAsync(int vehicleId);
        Task<List<Vehicle>> GetWithCompanyAsync();
        Task<List<Vehicle>> GetWithRouteAsync();
        Task<List<Vehicle>> GetWithSeatsAsync();
        Task<Vehicle> CreateWithSeatsAsync(Vehicle vehicle, int seatCount);
        Task<List<Vehicle>> GetByCompanyAsync(int companyId);
        Task<List<Vehicle>> GetByRouteAsync(int routeId);
    }
}
