using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Payment;

namespace TicketBooking.BLL.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentReadDTO?> GetAsync(int id);
        Task<List<PaymentReadDTO>> GetAllAsync();

        Task<bool> CreateAsync(PaymentCreateDTO dto);
        Task<decimal> GetTotalRevenueAsync();
        Task<bool> UpdateAsync(int id, PaymentCreateDTO dto);
        Task<bool> DeleteAsync(int id);

    }
}
