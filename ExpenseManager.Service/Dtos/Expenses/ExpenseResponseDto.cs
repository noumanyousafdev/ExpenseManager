using ExpenseManager.Service.Dtos.ExpenseDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Service.Dtos.Expenses
{
    public class ExpenseResponseDto
    {
        public Guid Id { get; set; }
        public string EmployeeId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime SubmissionDate { get; set; }
        public ICollection<ExpenseDetailResponseDto> ExpenseDetails { get; set; }
    }
}
