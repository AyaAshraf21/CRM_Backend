using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetCustomerNumForThisMonth
{
    public class GetCustomerNumForThisMonthHandler : IRequestHandler<GetCustomerNumForThisMonthQuery, int>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetCustomerNumForThisMonthHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<int> Handle(GetCustomerNumForThisMonthQuery request, CancellationToken cancellationToken)
        {
            return await analyticsRepository.GetCustomersNumForThisMonthAsync();
        }
    }
}
