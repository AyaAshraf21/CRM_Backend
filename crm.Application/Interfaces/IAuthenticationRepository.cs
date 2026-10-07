using crm.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Interfaces
{
    public interface IAuthenticationRepository
    {
        public Task<IdentityResult> RegisterAdminAsync(ApplicationUser user, string password);
        public Task<IdentityResult> RegisterEmployeeAsync(ApplicationUser user, string password);
        public Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        public Task<ApplicationUser> GetUserByNameAsync(string name);
    }
}
