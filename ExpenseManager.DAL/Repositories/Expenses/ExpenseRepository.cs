using ExpenseManager.Data;
using ExpenseManager.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.GenericRepository;

namespace ExpenseManager.DAL.Repositories.Expenses
{
    public class ExpenseRepository : GenericRepository<Expense> , IExpenseRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ExpenseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;     
        }
    }
}


    