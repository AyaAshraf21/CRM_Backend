using crm.Application.Features.Analytics.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetPaymentTypeAnalytics
{
    public class GetPaymentTypeAnalyticsHandler : IRequestHandler<GetPaymentTypeAnalyticsQuery, List<PaymentTypeAnalyticsDTO>>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetPaymentTypeAnalyticsHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<List<PaymentTypeAnalyticsDTO>> Handle(GetPaymentTypeAnalyticsQuery request, CancellationToken cancellationToken)
        {
            return await analyticsRepository.GetPaymentTypeAnalyticsAsync();
        }
    }
}
