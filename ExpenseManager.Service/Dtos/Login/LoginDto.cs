using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Service.Dtos.Login
{
    public class LoginDto
    {
        // Either Email or UserName is required
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
