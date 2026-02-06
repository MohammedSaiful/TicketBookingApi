using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.DAL.Entities;

namespace TicketBooking.DAL.Interfaces
{
    public interface ISearchFeature : IRepository<Route>
    {
        Task<List<Vehicle>> SearchAsync(string origin, string destination, DateTime? date);
        Task<List<Route>> SearchWithVehiclesAsync(string origin, string destination);
        Task<List<Route>> SearchByDateWithVehicleAsync(DateTime date);
    }
}
