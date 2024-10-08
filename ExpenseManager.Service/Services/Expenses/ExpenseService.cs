using AutoMapper;
using ExpenseManager.DAL.Repositories.Expenses;
using ExpenseManager.Models.Entities;
using ExpenseManager.Service.Dtos.Expenses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Service.Services.Expenses
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;  // Assuming you have a repository for Expense
        private readonly IMapper _mapper;

        public ExpenseService(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public async Task<ExpenseResponseDto> SubmitExpenseAsync(ExpenseCreateDto dto)
        {
            // Map the DTO to Expense entity (without setting the Employee object)
            var expense = _mapper.Map<Expense>(dto);

            // Calculate the total amount
            expense.TotalAmount = dto.ExpenseDetails.Sum(ed => ed.Amount);

            // Save the expense entity to the database
            _expenseRepository.Add(expense);
            await _expenseRepository.SaveAsync();

            // Map the entity back to a response DTO
            return _mapper.Map<ExpenseResponseDto>(expense);
        }
    }
}
