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
        public DbSet<ExpenseDetail> Expenses { get; set; }
        public DbSet<Expense> ExpenseForms { get; set; }
        //public DbSet<ApprovalHistory> ApprovalHistories { get; set; }
        //public DbSet<Report> Reports { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // For Expense entity
            modelBuilder.Entity<ExpenseDetail>()
                .Property(e => e.Amount)
                .HasColumnType("decimal(18,2)"); // Specify precision and scale

            // For ExpenseForm entity
            modelBuilder.Entity<Expense>()
                .Property(e => e.TotalAmount)
                .HasColumnType("decimal(18,2)"); // Specify precision and scale
        }

    }
}
