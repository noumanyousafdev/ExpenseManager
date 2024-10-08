using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Service.Dtos.ExpenseDetails
{
    public class ExpenseDetailCreateDto
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }

}
