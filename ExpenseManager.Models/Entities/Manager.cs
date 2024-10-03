using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExpenseManager.Models.Entities
{
    public class Manager : User, IBaseModel
    {
        public ICollection<Employee> Employees { get; set; } 
        public ICollection<ExpenseForm> ApprovedExpenseForms { get; set; }

        [JsonIgnore] 
        public bool IsDeleted { get; set; }

        [JsonIgnore] 
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; 

        [JsonIgnore] 
        public DateTime? UpdatedDate { get; set; }

        [JsonIgnore] 
        public DateTime? DeletedDate { get; set; }
    }
}
