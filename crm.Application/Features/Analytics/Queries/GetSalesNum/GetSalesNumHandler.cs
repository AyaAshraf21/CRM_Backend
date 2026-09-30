using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetSalesNum
{
    public class GetSalesNumHandler : IRequestHandler<GetSalesNumQuery, int>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetSalesNumHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public Task<int> Handle(GetSalesNumQuery request, CancellationToken cancellationToken)
        {
            return analyticsRepository.GetSalesNumAsync();
        }
    }
}
