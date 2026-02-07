using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.BLL.DTOs.Payment
{
    public class PaymentCreateDTO
    {
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; }
    }
}
