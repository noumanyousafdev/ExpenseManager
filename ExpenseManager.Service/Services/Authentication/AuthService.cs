using ExpenseManager.Models.Entities;
using ExpenseManager.Service.Dtos.Login;
using ExpenseManager.Service.Dtos.Register;
using ExpenseManager.Service.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Service.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        public AuthService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Register(RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };

            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                if (registerDto.Roles == null || !registerDto.Roles.Any())
                {
                    var defaultRoles = new List<string> { "Employee" }; 

                    var roleAssignmentResult = await AssignRoles(user, defaultRoles);
                    if (!roleAssignmentResult.Success)
                    {
                        return roleAssignmentResult;
                    }
                }
                else
                {
                    var roleAssignmentResult = await AssignRoles(user, registerDto.Roles);
                    if (!roleAssignmentResult.Success)
                    {
                        return roleAssignmentResult;
                    }
                }

                return ServiceResponse<string>.ReturnResultWith200("User registered successfully.");
            }

            return ServiceResponse<string>.ReturnFailed(400, result.Errors.Select(e => e.Description).ToList());
        }

        public async Task<ServiceResponse<string>> AssignRoles(User user, List<string> roles)
        {
            foreach (var role in roles)
            {
                if (await roleManager.RoleExistsAsync(role))
                {
                    var roleResult = await userManager.AddToRoleAsync(user, role);
                    if (!roleResult.Succeeded)
                    {
                        return ServiceResponse<string>.ReturnFailed(400, $"Failed to assign role '{role}'.");
                    }
                }
                else
                {
                    return ServiceResponse<string>.ReturnFailed(400, $"Role '{role}' does not exist.");
                }
            }

            return ServiceResponse<string>.ReturnResultWith200("Roles assigned successfully.");
        }

        public async Task<ServiceResponse<string>> Login(LoginDto loginDto)
        {
            User user;

            if (!string.IsNullOrEmpty(loginDto.Email) && IsValidEmail(loginDto.Email))
            {
                // Attempt to find by email
                user = await userManager.FindByEmailAsync(loginDto.Email);
            }
            else if (!string.IsNullOrEmpty(loginDto.UserName))
            {
                // Attempt to find by username
                user = await userManager.FindByNameAsync(loginDto.UserName);
            }
            else
            {
                return ServiceResponse<string>.ReturnFailed(400, "Username or Email is required.");
            }

            // Check if the user exists and password is valid
            if (user == null || !await userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return ServiceResponse<string>.ReturnFailed(401, "Invalid login credentials.");
            }

            // Get user roles
            var roles = await userManager.GetRolesAsync(user);
            if (roles.Any())
            {
                // Generate JWT token
                var tokenResponse = CreateJwtToken(user, roles.ToList());
                return tokenResponse;
            }

            return ServiceResponse<string>.ReturnFailed(401, "User has no assigned roles.");
        }

        private bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public ServiceResponse<string> CreateJwtToken(User user, List<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return ServiceResponse<string>.ReturnResultWith200(tokenString);
        }
    }
}
