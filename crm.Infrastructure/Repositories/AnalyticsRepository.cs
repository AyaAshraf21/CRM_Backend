using Azure.Core;
using crm.Application.Features.Analytics.DTOs;
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

        public async Task<List<MonthlyCustomerCountDTO>> GetCustomersPerMonthAsync()
        {
            return await context.Customers.Where(c => !c.IsDeleted)
                        .GroupBy(c => new
                        {
                            c.CreatedAt.Year,
                            c.CreatedAt.Month
                        })
                        .Select(g => new MonthlyCustomerCountDTO
                        {
                            Year = g.Key.Year,
                            Month = g.Key.Month,
                            Count = g.Count()
                        })
                        .OrderBy(x => x.Year)
                        .ThenBy(x => x.Month)
                        .ToListAsync();
        }

        public async Task<MonthlyCustomerCountDTO> GetBestMonthAsync()
        {
            return await context.Customers.Where(c => !c.IsDeleted)
                                    .GroupBy(c => new
                                    {
                                        c.CreatedAt.Year,
                                        c.CreatedAt.Month,
                                    }).Select( g=> new MonthlyCustomerCountDTO
                                    {
                                        Year = g.Key.Year,
                                        Month = g.Key.Month,
                                        Count = g.Count()
                                    })
                                    .OrderByDescending(x => x.Count)
                                    .FirstOrDefaultAsync();
        }

        public async Task<int> GetAverageCustomersPerMonthAsync()
        {
            var result = await context.Customers.Where(c => !c.IsDeleted)
                                    .GroupBy(c => new
                                    {
                                        c.CreatedAt.Year,
                                        c.CreatedAt.Month,
                                    })
                                    .Select(g => g.Count())
                                    .AverageAsync();
            return (int)result;
                                    
        }

        public async Task<List<PlatformsAnalyticsDTO>> GetPlatformsAnalyticsAsync()
        {
            var platformFollowups = context.Followups
                        .Where(f => !f.IsDeleted)
                        .GroupBy(f => f.Platform)
                        .Select(g => new
                        {
                            Platform = g.Key,
                            FollowupCount = g.Count()
                        });

            var platformSales = context.Followups
                        .Where(f =>
                            !f.IsDeleted &&
                            f.OperationType == OperationType.Selling &&
                            f.StatusHistory
                                .OrderByDescending(s => s.ChangedAt)
                                .ThenByDescending(s => s.Id)
                                .Select(s => s.Status)
                                .FirstOrDefault() == Status.Purchased)
                        .GroupBy(f => f.Platform)
                        .Select(g => new
                        {
                            Platform = g.Key,
                            PurchasedCount = g.Count()
                        });

            var result = await platformFollowups
                        .GroupJoin(
                            platformSales,
                            pf => pf.Platform,
                            ps => ps.Platform,
                            (pf, sales) => new
                            {
                                pf.Platform,
                                pf.FollowupCount,
                                PurchasedCount = sales
                                    .Select(x => x.PurchasedCount)
                                    .FirstOrDefault()
                            })
                        .Select(x => new PlatformsAnalyticsDTO
                        {
                            PlatformId = x.Platform,
                            Platform = x.Platform.ToString(),
                            FollowupCount = x.FollowupCount,
                            PurchasedCount = x.PurchasedCount,
                            ConversionRate = (double)x.PurchasedCount / x.FollowupCount * 100
                        })
                        .OrderByDescending(x => x.ConversionRate)
                        .ToListAsync();

            return result;
        }

        public async Task<List<FollowupStatusAnalyticsDTO>> GetFollowupStatusAnalyticsAsync()
        {
            return await context.StatusHistory.GroupBy(s => s.Status)
                                    .Select(g => new FollowupStatusAnalyticsDTO
                                    {
                                        StatusId = g.Key,
                                        Status = g.Key.ToString(),
                                        FollowupCount = g.Count()
                                    }).OrderByDescending(s => s.FollowupCount)
                                    .ToListAsync();
        }

        public async Task<List<CustomerTagAnalyticsDTO>> GetCustomerTagAnalyticsAsync()
        {
            return await context.Customers.Where(c => !c.IsDeleted)
                                    .GroupBy(c => c.Tag)
                                    .Select(g => new CustomerTagAnalyticsDTO
                                    {
                                        TagId = g.Key.Id,
                                        Tag = g.Key.Name,
                                        CustomerCount = g.Count()
                                    }).OrderByDescending(c => c.CustomerCount)
                                    .ToListAsync();
        }

        public async Task<List<PaymentTypeAnalyticsDTO>> GetPaymentTypeAnalyticsAsync()
        {
            return await context.Followups.Where(f => !f.IsDeleted)
                                    .GroupBy(f => f.PaymentType)
                                    .Select(g => new PaymentTypeAnalyticsDTO
                                    {
                                        PaymentTypeId = g.Key,
                                        PaymentType = g.Key.ToString(),
                                        FollowupCount = g.Count()
                                    })
                                    .ToListAsync();
        }
    }
}
