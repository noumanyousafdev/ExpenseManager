﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Models.Entities
{
    public class Expense : BaseModel
    {
        public Guid Id { get; set; }
        // Foreign key to the User (Employee)
        public string EmployeeId { get; set; }

        // Navigation property to User
        public virtual User Employee { get; set; }
        public decimal TotalAmount { get; set; }  
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Approved ,  Pending , Rejected  
        public string ReasonForRejection { get; set; } 
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
        public ICollection<ExpenseDetail> ExpenseDetails { get; set; } = new List<ExpenseDetail>(); 

    }
}


// 
