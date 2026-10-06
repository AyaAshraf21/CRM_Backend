using crm.Application.Features.Analytics.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetGovernorateAnalytics
{
    public class GetGovernorateAnalyticsHandler : IRequestHandler<GetGovernorateAnalyticsQuery, List<GovernorateAnalyticsDTO>>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetGovernorateAnalyticsHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<List<GovernorateAnalyticsDTO>> Handle(GetGovernorateAnalyticsQuery request, CancellationToken cancellationToken)
        {
            return await analyticsRepository.GetGovernorateAnalyticsAsync();
        }
    }
}
