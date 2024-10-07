using ExpenseManager.Service.Dtos.Login;
using ExpenseManager.Service.Dtos.Register;
using ExpenseManager.Service.Services.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var response = await authService.Register(registerDto);
            return ReturnFormattedResponse(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var response = await authService.Login(loginDto);
            return ReturnFormattedResponse(response);
        }
    }
}
