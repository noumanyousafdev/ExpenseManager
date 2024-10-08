using ExpenseManager.Service.Dtos.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Service.Services.Expenses
{
    public interface IExpenseService
    {
        Task<ExpenseResponseDto> SubmitExpenseAsync(ExpenseCreateDto dto);
    }
}
