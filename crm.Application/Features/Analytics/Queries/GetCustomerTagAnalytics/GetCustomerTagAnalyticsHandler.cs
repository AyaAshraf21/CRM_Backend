using crm.Application.Features.Analytics.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetCustomerTagAnalytics
{
    public class GetCustomerTagAnalyticsHandler : IRequestHandler<GetCustomerTagAnalyticsQuery, List<CustomerTagAnalyticsDTO>>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetCustomerTagAnalyticsHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<List<CustomerTagAnalyticsDTO>> Handle(GetCustomerTagAnalyticsQuery request, CancellationToken cancellationToken)
        {
            return await analyticsRepository.GetCustomerTagAnalyticsAsync();
        }
    }
}
