using crm.Application.Interfaces;
using crm.Domain.Entities;
using crm.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace crm.Infrastructure.Repositories
{
    public class JwtRepository : IJwtRepository
    {
        private readonly JwtSettings jwtSettings;
        private readonly UserManager<ApplicationUser> userManager;

        public JwtRepository(IOptions<JwtSettings> jwtSettings, UserManager<ApplicationUser> userManager)
        {
            this.jwtSettings = jwtSettings.Value;
            this.userManager = userManager;
        }

        public async Task<string> GenerateToken(ApplicationUser user)
        {
            var roles = await userManager.GetRolesAsync(user);

            var userClaims = new List<Claim>();
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            userClaims.Add(new Claim(ClaimTypes.Name, user.UserName));

            foreach (var role in roles)
            {
                userClaims.Add(
                    new Claim(ClaimTypes.Role, role)
                );
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));

            var signingCredintials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                claims: userClaims,
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCredintials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
