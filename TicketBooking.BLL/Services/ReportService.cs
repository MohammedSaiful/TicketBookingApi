using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Report;
using TicketBooking.BLL.Interfaces;
using TicketBooking.DAL;

namespace TicketBooking.BLL.Services
{
    public class ReportService : IReportService
    {
        private readonly DataAccessFactory _factory;
        private readonly IMapper _mapper;

        public ReportService(DataAccessFactory factory, IMapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }

        public async Task<DashboardReportDTO> GetDashboardAsync()
        {
            var totalBookings = await _factory.ReportData().GetTotalBookingsAsync();
            var totalRevenue = await _factory.ReportData().GetTotalRevenueAsync();

            return new DashboardReportDTO
            {
                TotalBookings = totalBookings,
                TotalRevenue = totalRevenue
            };
        }

        public async Task<List<TopRouteDTO>> GetTopRoutesAsync()
        {
            var topRoutes = await _factory.ReportData().GetTopRoutesAsync();
            return _mapper.Map<List<TopRouteDTO>>(topRoutes);
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _factory.ReportData().GetTotalRevenueAsync();
        }
    }
}
