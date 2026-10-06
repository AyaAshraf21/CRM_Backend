using crm.Application.Features.Analytics.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetDeviceConditionAnalytics
{
    public class GetDeviceConditionAnalyticsHandler : IRequestHandler<GetDeviceConditionAnalyticsQuery, List<DeviceConditionAnalyticsDTO>>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetDeviceConditionAnalyticsHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<List<DeviceConditionAnalyticsDTO>> Handle(GetDeviceConditionAnalyticsQuery request, CancellationToken cancellationToken)
        {
            return await analyticsRepository.GetDeviceConditionAnalyticsAsync();
        }
    }
}
