using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Service.Dtos.Register
{
    public class RegisterDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        public List<string>? Roles { get; set; }
    }
}
