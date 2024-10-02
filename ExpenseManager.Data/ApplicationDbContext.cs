using ExpenseManager.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
    }
}
