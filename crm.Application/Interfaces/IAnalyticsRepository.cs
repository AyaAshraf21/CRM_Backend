using crm.Application.Features.Analytics.DTOs;
using crm.Domain.Entities;
using crm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Interfaces
{
    public interface IAnalyticsRepository
    {
        public Task<Platform> GetBestPlatformAsync();
        public Task<string?> GetTopGovernorateAsync();
        public Task<string?> GetTopDeviceAsync();
        public Task<int> GetSalesNumAsync();
        public Task<int> GetCustomersNumForThisMonthAsync();
        public Task<int> GetSalesNumForThisMonthAsync();
        public Task<int> GetSalesNumForLastMonthAsync();
        public Task<List<MonthlyCustomerCountDTO>> GetCustomersPerMonthAsync();
        public Task<MonthlyCustomerCountDTO> GetBestMonthAsync();
        public Task<int> GetAverageCustomersPerMonthAsync();
        public Task<List<PlatformsAnalyticsDTO>> GetPlatformsAnalyticsAsync();
        public Task<List<FollowupStatusAnalyticsDTO>> GetFollowupStatusAnalyticsAsync();
        public Task<List<CustomerTagAnalyticsDTO>> GetCustomerTagAnalyticsAsync();
    }
}
