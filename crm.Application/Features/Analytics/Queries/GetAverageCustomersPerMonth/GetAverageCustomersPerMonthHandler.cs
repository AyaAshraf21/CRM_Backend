using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetAverageCustomersPerMonth
{
    public class GetAverageCustomersPerMonthHandler : IRequestHandler<GetAverageCustoemrsPerMonthQuery, int>
    {
        private readonly IAnalyticsRepository analyticsRepository;
        public GetAverageCustomersPerMonthHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }
        public async Task<int> Handle(GetAverageCustoemrsPerMonthQuery request, CancellationToken cancellationToken)
        {
            return await analyticsRepository.GetAverageCustomersPerMonthAsync();
        }
    }
}
