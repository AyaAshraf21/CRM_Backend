using crm.Application.Features.Analytics.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetOperationTypeAnalytics
{
    public class GetOperationTypeAnalyticsHandler : IRequestHandler<GetOperationTypeAnalyticsQuery, List<OperationTypeAnalyticsDTO>>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetOperationTypeAnalyticsHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<List<OperationTypeAnalyticsDTO>> Handle(GetOperationTypeAnalyticsQuery request, CancellationToken cancellationToken)
        {
            return await analyticsRepository.GetOperationTypeAnalyticsAsync();
        }
    }
}
