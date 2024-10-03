using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExpenseManager.Models.Entities
{
    public class Manager : User
    {
        public ICollection<Employee> Employees { get; set; } 
        public ICollection<Expense> ApprovedExpenseForms { get; set; }
    }
}
