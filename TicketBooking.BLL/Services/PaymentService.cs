using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.BLL.DTOs.Payment;
using TicketBooking.BLL.Interfaces;
using TicketBooking.DAL;
using TicketBooking.DAL.Entities;

namespace TicketBooking.BLL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly DataAccessFactory _factory;
        private readonly IMapper _mapper;

        public PaymentService(DataAccessFactory factory, IMapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }

        public async Task<PaymentReadDTO?> GetAsync(int id)
        {
            var payment = await _factory.PaymentData().GetAsync(id);
            return payment == null ? null : _mapper.Map<PaymentReadDTO>(payment);
        }

        public async Task<List<PaymentReadDTO>> GetAllAsync()
        {
            var payments = await _factory.PaymentData().GetAllAsync();
            return _mapper.Map<List<PaymentReadDTO>>(payments);
        }

        public async Task<bool> CreateAsync(PaymentCreateDTO dto)
        {
            var payment = _mapper.Map<Payment>(dto);
            payment.Status = PaymentStatus.Pending;
            payment.PaymentDate = DateTime.Now;

            return await _factory.PaymentData().CreateAsync(payment);
        }

        public async Task<bool> UpdateAsync(int id, PaymentCreateDTO dto)
        {
            var payment = await _factory.PaymentData().GetAsync(id);
            if (payment == null) return false;

            payment.Amount = dto.Amount;
            payment.Method = dto.Method;

            return await _factory.PaymentData().UpdateAsync(payment);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _factory.PaymentData().DeleteAsync(id);
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _factory.PaymentData().GetTotalRevenueAsync();
        }
    }
}
