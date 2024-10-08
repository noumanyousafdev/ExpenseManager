using ExpenseManager.Service.Dtos.ExpenseDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Service.Dtos.Expenses
{
    public class ExpenseCreateDto
    {
        public string EmployeeId { get; set; }

        public string Currency { get; set; }
        public string Description { get; set; }
        public List<ExpenseDetailCreateDto> ExpenseDetails { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
