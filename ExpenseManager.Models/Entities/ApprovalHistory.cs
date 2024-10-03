using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Models.Entities
{
    public class ApprovalHistory
    {
        public Guid ApprovalId { get; set; }
        public Guid ExpenseFormId { get; set; } 
        public string ApproverId { get; set; } 
        public string ApprovalStatus { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
    }
}
