using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.DAL.Entities;

namespace TicketBooking.DAL.Interfaces
{
    public interface ICompanyFeature: IRepository<Company>
    {
        Task<Company?> GetWithVehiclesAsync(int companyId);
        Task<int> VehicleCountAsync(int companyId);
    }
}
