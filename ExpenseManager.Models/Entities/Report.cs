using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Models.Entities
{
    public class Report : BaseModel
    {
        public Guid ReportId { get; set; }
        public string EmployeeId { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
