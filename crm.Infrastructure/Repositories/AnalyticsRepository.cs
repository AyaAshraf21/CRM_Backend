using crm.Application.Interfaces;
using crm.Domain.Entities;
using crm.Domain.Enums;
using crm.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Infrastructure.Repositories
{
    public class AnalyticsRepository : IAnalyticsRepository
    {
        private readonly CRMContext context;
        public AnalyticsRepository(CRMContext crmContext)
        {
            this.context = crmContext;
        }

        public async Task<Platform> GetBestPlatformAsync()
        {
            return await context.Followups
                .Where(f => !f.IsDeleted)
                .GroupBy(f => f.Platform)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefaultAsync();
        }

        public async Task<string?> GetTopGovernorate()
        {
            return await context.Followups
                            .Where(f => !f.IsDeleted &&
                                   f.OperationType == OperationType.Selling &&
                                   f.StatusHistory
                                       .OrderByDescending(s => s.ChangedAt)
                                       .ThenByDescending(s => s.Id)
                                       .Select(s => s.Status)
                                       .FirstOrDefault() == Status.Purchased)
                            .GroupBy(f => f.Customer.Area.Governorate.Name)
                            .OrderByDescending(g => g.Count())
                            .Select(g => g.Key)
                            .FirstOrDefaultAsync();
        }
    }
}
