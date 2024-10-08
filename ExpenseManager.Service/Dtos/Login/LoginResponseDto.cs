﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Service.Dtos.Login
{
    public class LoginResponseDto
    {
        public string JwtToken { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public List<string> Roles { get; set; }
        public DateTime Expiration { get; set; }
    }
}
