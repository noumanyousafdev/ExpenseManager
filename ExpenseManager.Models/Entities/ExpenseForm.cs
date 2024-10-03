using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Models.Entities
{
    public class ExpenseForm : BaseModel
    {
        public Guid Id { get; set; } 
        public string EmployeeId { get; set; } 
        public decimal TotalAmount { get; set; }  
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } 
        public string ReasonForRejection { get; set; } 
        public DateTime SubmissionDate { get; set; }
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>(); 
        public Employee Employee { get; set; } 
    }
}
