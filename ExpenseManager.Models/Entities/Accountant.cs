﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExpenseManager.Models.Entities
{
    public class Accountant : User
    {
        public ICollection<Expense> PaidExpenseForms { get; set; }
    }
}
