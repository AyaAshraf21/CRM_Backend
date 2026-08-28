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
    public class AreaRepository : IAreaRepository
    {
        private readonly CRMContext context;

        public AreaRepository(CRMContext context)
        {
            this.context = context;
        }

        public async Task<List<Area>> GetAllAreasByGovernorateAsync(int governorateId)
        {
            return await context.Areas.Where(a => a.GovernorateId == governorateId).ToListAsync();
        }
    }
}
