using ExpenseManager.Service.Dtos.Expenses;
using ExpenseManager.Service.Services.Expenses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost]
        [Route("submit")]
        public async Task<IActionResult> SubmitExpense([FromBody] ExpenseCreateDto expenseCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _expenseService.SubmitExpenseAsync(expenseCreateDto);
            return Ok(result);  // Return the response DTO
        }
    }
}
