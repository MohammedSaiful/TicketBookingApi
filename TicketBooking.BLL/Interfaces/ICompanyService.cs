using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Company;

namespace TicketBooking.BLL.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyReadDTO?> GetAsync(int id);
        Task<List<CompanyReadDTO>> GetAllAsync();

        Task<CompanyVehicleDTO?> GetWithVehiclesAsync(int companyId);

        Task<bool> CreateAsync(CompanyCreateDTO dto);
        Task<bool> UpdateAsync(int id, CompanyCreateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
