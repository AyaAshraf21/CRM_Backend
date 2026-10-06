using crm.Application.Features.Analytics.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetAreaAnalytics
{
    public class GetAreaAnalyticsHandler : IRequestHandler<GetAreaAnalyticsQuery, List<AreaAnalyticsDTO>>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetAreaAnalyticsHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<List<AreaAnalyticsDTO>> Handle(GetAreaAnalyticsQuery request, CancellationToken cancellationToken)
        {
            return await analyticsRepository.GetAreaAnalyticsAsync();
        }
    }
}
