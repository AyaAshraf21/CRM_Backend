using crm.Application.Interfaces;
using crm.Domain.Entities;
using crm.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Infrastructure.Repositories
{
    public class GovernorateRepository : IGovernorateRepository
    {
        private readonly CRMContext context;

        public GovernorateRepository(CRMContext context)
        {
            this.context = context;
        }

        public async Task<List<Governorate>> GetAllGovernoratesAsync()
        {
            return await context.Governorates.ToListAsync();
        }

        public async Task<bool> IsGovernorateExistsById(int id)
        {
            return await context.Governorates.AnyAsync(g => g.Id == id);
        }
    }
}
