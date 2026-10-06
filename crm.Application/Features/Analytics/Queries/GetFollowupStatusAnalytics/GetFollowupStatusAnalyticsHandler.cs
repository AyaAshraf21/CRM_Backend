using crm.Application.Features.Analytics.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetFollowupStatusAnalytics
{
    public class GetFollowupStatusAnalyticsHandler : IRequestHandler<GetFollowupStatusAnalyticsQuery, List<FollowupStatusAnalyticsDTO>>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetFollowupStatusAnalyticsHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<List<FollowupStatusAnalyticsDTO>> Handle(GetFollowupStatusAnalyticsQuery request, CancellationToken cancellationToken)
        {
            return await analyticsRepository.GetFollowupStatusAnalyticsAsync();
        }
    }
}
