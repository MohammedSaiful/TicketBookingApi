using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Company;
using TicketBooking.BLL.Interfaces;
using TicketBooking.DAL;

namespace TicketBooking.BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly DataAccessFactory _factory;
        private readonly IMapper _mapper;

        public CompanyService(DataAccessFactory factory, IMapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }

        public async Task<CompanyReadDTO?> GetAsync(int id)
        {
            var company = await _factory.CompanyData().GetAsync(id);
            return company == null ? null : _mapper.Map<CompanyReadDTO>(company);
        }

        public async Task<List<CompanyReadDTO>> GetAllAsync()
        {
            var companies = await _factory.CompanyData().GetAllAsync();
            return _mapper.Map<List<CompanyReadDTO>>(companies);
        }

        public async Task<CompanyVehicleDTO?> GetWithVehiclesAsync(int companyId)
        {
            var company = await _factory.CompanyData().GetWithVehiclesAsync(companyId);
            return company == null ? null : _mapper.Map<CompanyVehicleDTO>(company);
        }

        public async Task<bool> CreateAsync(CompanyCreateDTO dto)
        {
            var entity = _mapper.Map<TicketBooking.DAL.Entities.Company>(dto);
            return await _factory.CompanyData().CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(int id, CompanyCreateDTO dto)
        {
            var company = await _factory.CompanyData().GetAsync(id);
            if (company == null) return false;

            company.Name = dto.Name;
            return await _factory.CompanyData().UpdateAsync(company);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _factory.CompanyData().DeleteAsync(id);
        }
    }
}
