using ExpenseManager.Models.Entities;
using ExpenseManager.Service.Dtos.Login;
using ExpenseManager.Service.Dtos.Register;
using ExpenseManager.Service.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Service.Services.Authentication
{
    public interface IAuthService
    {

        Task<ServiceResponse<string>> Register(RegisterDto registerDto);

        Task<ServiceResponse<string>> AssignRoles(User user, List<string> roles);

        Task<ServiceResponse<LoginResponseDto>> Login(LoginDto loginDto);

        TokenResponseDto CreateJwtToken(User user, List<string> roles);
    }
}
