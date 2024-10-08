using ExpenseManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.GenericRepository;

namespace ExpenseManager.DAL.Repositories.Expenses
{
    public interface IExpenseRepository : IGenericRepository<Expense>
    {
    }
}
