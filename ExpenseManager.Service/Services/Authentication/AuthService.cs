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
            // Check if the ManagerId is provided and exists
            User manager = null;
            if (!string.IsNullOrEmpty(registerDto.ManagerId))
            {
                manager = await userManager.FindByIdAsync(registerDto.ManagerId);
                if (manager == null)
                {
                    return ServiceResponse<string>.ReturnFailed(400, "Manager not found.");
                }
            }

            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                ManagerId = registerDto.ManagerId 
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

        public async Task<ServiceResponse<LoginResponseDto>> Login(LoginDto loginDto)
        {
            User user = null;

            if (IsValidEmail(loginDto.UsernameOrEmail))
            {
                user = await userManager.FindByEmailAsync(loginDto.UsernameOrEmail);
            }
            else
            {
                user = await userManager.FindByNameAsync(loginDto.UsernameOrEmail);
            }

            if (user == null || !await userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return ServiceResponse<LoginResponseDto>.ReturnFailed(401, "Invalid login credentials.");
            }

            var roles = await userManager.GetRolesAsync(user);
            if (!roles.Any())
            {
                return ServiceResponse<LoginResponseDto>.ReturnFailed(401, "User has no assigned roles.");
            }

            var tokenResponse = CreateJwtToken(user, roles.ToList());
            var loginResponseDto = new LoginResponseDto
            {
                JwtToken = tokenResponse.JwtToken,
                Username = user.UserName,
                UserId = user.Id,
                Roles = roles.ToList(),
                Expiration = tokenResponse.Expiration
            };

            return ServiceResponse<LoginResponseDto>.ReturnResultWith200(loginResponseDto);
        }

        private bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public TokenResponseDto CreateJwtToken(User user, List<string> roles)
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

            var expiration = DateTime.UtcNow.AddMinutes(int.Parse(configuration["Jwt:ExpirationInMinutes"]));

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenResponseDto
            {
                JwtToken = tokenString,
                Expiration = expiration
            };
        }
    }

 }
