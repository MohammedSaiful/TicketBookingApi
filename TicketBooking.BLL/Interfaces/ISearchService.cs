using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Search;

namespace TicketBooking.BLL.Interfaces
{
    public interface ISearchService
    {
        Task<List<SearchRouteDTO>> GetAllRoutesAsync();

        Task<List<VehicleDTO>> SearchAsync(string origin, string destination, DateTime? date);

        Task<List<SearchRouteVehicleDTO>> SearchWithVehiclesAsync(string origin, string destination);
        Task<List<SearchRouteVehicleDTO>> SearchByDateWithVehicleAsync(DateTime date);
    }
}
