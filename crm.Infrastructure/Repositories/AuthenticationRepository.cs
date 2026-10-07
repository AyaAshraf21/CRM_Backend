using crm.Application.Interfaces;
using crm.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AuthenticationRepository(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<bool> ChangePassword(ApplicationUser applicationUser, string currentPassword, string newPassword)
        {
            var result = await userManager.ChangePasswordAsync(applicationUser, currentPassword, newPassword);
            return result.Succeeded;
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await userManager.CheckPasswordAsync(user, password);
        }

        public async Task<ApplicationUser> GetUserByNameAsync(string name)
        {
            return await userManager.FindByNameAsync(name);
        }

        public async Task<IdentityResult> RegisterAdminAsync(ApplicationUser user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
            return result;

        }

        public async Task<IdentityResult> RegisterEmployeeAsync(ApplicationUser user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Employee");
            }
            return result;
        }
    }
}
