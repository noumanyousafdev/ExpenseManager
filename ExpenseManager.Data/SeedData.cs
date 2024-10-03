using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Data
{
    public static class SeedData
    {
        public static async Task SeedInitial(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Seed Roles if they don't exist
            var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = "5bd1711f-38cc-47ce-960b-242d82b86a18",
                Name = "Admin",
                NormalizedName = "ADMIN",
            },
            new IdentityRole
            {
                Id = "7c1a9a70-8c4b-4c99-8d09-5e4c8b4e3e15",
                Name = "Manager",
                NormalizedName = "MANAGER",
            },
            new IdentityRole
            {
                Id = "8a7b1c90-19b6-4e72-b6c9-5a1c8c8e1f26",
                Name = "Employee",
                NormalizedName = "EMPLOYEE",
            },
            new IdentityRole
            {
                Id = "d29f2b99-8f8b-4c89-9b0c-5b6f4d8920a3",
                Name = "Accountant",
                NormalizedName = "ACCOUNTANT",
            }
        };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role.Name))
                {
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}
