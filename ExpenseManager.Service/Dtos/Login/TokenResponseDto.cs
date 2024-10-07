using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Service.Dtos.Login
{
    public class TokenResponseDto
    {
        public string JwtToken { get; set; }
        public DateTime Expiration { get; set; }
    }

}
