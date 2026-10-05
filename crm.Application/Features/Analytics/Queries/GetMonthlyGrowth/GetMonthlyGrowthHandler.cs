using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetMonthlyGrowth
{
    public class GetMonthlyGrowthHandler : IRequestHandler<GetMonthlyGrowthQuery, double>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetMonthlyGrowthHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<double> Handle(GetMonthlyGrowthQuery request, CancellationToken cancellationToken)
        {
            var salesLastMonth = await analyticsRepository.GetSalesNumForLastMonthAsync();
            var salesThisMonth = await analyticsRepository.GetSalesNumForThisMonthAsync();

            var monthlyGrowth =
                    salesLastMonth > 0
                            ? ((salesThisMonth - salesLastMonth) / (double)salesLastMonth) * 100
                            : (salesThisMonth > 0 ? 100.0 : 0.0);
            return monthlyGrowth;
        }
    }
}
