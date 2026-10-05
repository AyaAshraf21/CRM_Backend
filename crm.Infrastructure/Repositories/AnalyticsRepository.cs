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
                .Where(f => !f.IsDeleted &&
                        f.OperationType == OperationType.Selling &&
                        f.StatusHistory
                                       .OrderByDescending(s => s.ChangedAt)
                                       .ThenByDescending(s => s.Id)
                                       .Select(s => s.Status)
                                       .FirstOrDefault() == Status.Purchased)
                .GroupBy(f => f.Platform)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefaultAsync();
        }

        public async Task<string?> GetTopGovernorateAsync()
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

        public async Task<string?> GetTopDeviceAsync()
        {
            return await context.Followups
                            .Where(f => !f.IsDeleted &&
                                    f.OperationType == OperationType.Selling &&
                                    f.StatusHistory
                                        .OrderByDescending(s => s.ChangedAt)
                                        .ThenByDescending(s => s.Id)
                                        .Select(s => s.Status)
                                        .FirstOrDefault() == Status.Purchased)
                            .GroupBy(f => f.DeviceType)
                            .OrderByDescending(g => g.Count())
                            .Select(g => g.Key)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> GetSalesNumAsync()
        {
            return await context.Followups
                                .Where(f => !f.IsDeleted &&
                                        f.OperationType == OperationType.Selling &&
                                        f.StatusHistory
                                        .OrderByDescending(s => s.ChangedAt)
                                        .ThenByDescending(s => s.Id)
                                        .Select(s => s.Status)
                                        .FirstOrDefault() == Status.Purchased)
                                .CountAsync();
                                
        }

        public async Task<int> GetCustomersNumForThisMonthAsync()
        {
            return await context.Customers.Where(c => !c.IsDeleted &&
                                                    c.CreatedAt.Month == DateTime.UtcNow.Month &&
                                                    c.CreatedAt.Year == DateTime.UtcNow.Year).CountAsync();
        }
        
        public async Task<int> GetSalesNumForThisMonthAsync()
        {
            return await context.Followups.Where(f => !f.IsDeleted &&
                                        f.OperationType == OperationType.Selling &&
                                        f.CreatedAt.Month == DateTime.UtcNow.Month &&
                                        f.CreatedAt.Year == DateTime.UtcNow.Year &&
                                        f.StatusHistory
                                        .OrderByDescending(s => s.ChangedAt)
                                        .ThenByDescending(s => s.Id)
                                        .Select(s => s.Status)
                                        .FirstOrDefault() == Status.Purchased
                                        ).CountAsync();
        }

        public Task<int> GetSalesNumForLastMonthAsync()
        {
            var now = DateTime.UtcNow;

            var startOfLastMonth = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
            var startOfThisMonth = new DateTime(now.Year, now.Month, 1);

            return context.StatusHistory
                .Where(s =>
                    s.Status == Status.Purchased &&
                    s.ChangedAt >= startOfLastMonth &&
                    s.ChangedAt < startOfThisMonth &&
                    !s.Followup.IsDeleted &&
                    s.Followup.OperationType == OperationType.Selling
                )
                .CountAsync();
        }
    }
}
