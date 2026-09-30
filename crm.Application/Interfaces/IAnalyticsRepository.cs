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
    }
}
