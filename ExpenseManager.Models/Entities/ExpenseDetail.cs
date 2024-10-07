using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Models.Entities
{
    public class ExpenseDetail : BaseModel
    {
        public Guid Id { get; set; }
        public Guid ExpenseId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public Expense Expense { get; set; }
    }
}
