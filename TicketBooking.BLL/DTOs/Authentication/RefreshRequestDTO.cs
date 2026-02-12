using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.BLL.DTOs.Authentication
{
    public class RefreshRequestDTO
    {
        public string RefreshToken { get; set; } = string.Empty;
    }
}
