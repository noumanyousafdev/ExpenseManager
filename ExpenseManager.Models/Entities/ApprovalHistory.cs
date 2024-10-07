using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Models.Entities
{
    public class ApprovalHistory
    {
        public Guid Id { get; set; } 
        public Guid ExpenseId { get; set; }
        public Expense Expense { get; set; } 

        // Foreign key to link to the User (approver)
        public string ApprovedById { get; set; }
        public User ApprovedBy { get; set; } 
        public string Status { get; set; } // e.g., "Approved", "Rejected", "Pending"
        public DateTime ApprovedDate { get; set; } = DateTime.UtcNow; 
    }
}


