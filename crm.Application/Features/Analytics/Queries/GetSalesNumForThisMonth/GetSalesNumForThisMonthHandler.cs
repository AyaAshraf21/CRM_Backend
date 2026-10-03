using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetSalesNumForThisMonth
{
    public class GetSalesNumForThisMonthHandler : IRequestHandler<GetSalesNumForThisMonthQuery, int>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetSalesNumForThisMonthHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<int> Handle(GetSalesNumForThisMonthQuery request, CancellationToken cancellationToken)
        {
            return await analyticsRepository.GetSalesNumForThisMonthAsync();
        }
    }
}
