using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Booking;
using TicketBooking.BLL.DTOs.Vehicle;

namespace TicketBooking.BLL.Interfaces
{
    public interface IVehicleService
    {
        Task<List<VehicleCompanyDTO>> GetAllAsync();
        Task<VehicleCompanyDTO?> GetAsync(int id);

        Task<List<VehicleCompanyDTO>> GetByCompanyAsync(int companyId);
        Task<List<VehicleRouteDTO>> GetByRouteAsync(int routeId);

        Task<List<SeatDTO>> GetAvailableSeatsAsync(int vehicleId);

        Task<bool> CreateAsync(VehicleCreateDTO dto);
        Task<bool> DeleteAsync(int id);

    }
}
