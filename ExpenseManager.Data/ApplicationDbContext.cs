using ExpenseManager.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Accountant> Accountants { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseForm> ExpenseForms { get; set; }
        //public DbSet<ApprovalHistory> ApprovalHistories { get; set; }
        //public DbSet<Report> Reports { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
