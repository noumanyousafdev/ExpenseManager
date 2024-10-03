using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Models.Entities
{
    public class Expense : BaseModel
    {
        public Guid Id { get; set; }
        public Guid ExpenseFormId { get; set; }
        public ExpenseForm ExpenseForm { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
