﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Models.Entities
{
    public class User : IdentityUser 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ManagerId { get; set; } 
        public virtual User Manager { get; set; } 
    }
}

