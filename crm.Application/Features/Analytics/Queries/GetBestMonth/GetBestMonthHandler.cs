using crm.Application.Features.Analytics.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetBestMonth
{
    public class GetBestMonthHandler : IRequestHandler<GetBestMonthQuery, MonthlyCustomerCountDTO>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetBestMonthHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<MonthlyCustomerCountDTO> Handle(GetBestMonthQuery request, CancellationToken cancellationToken)
        {
            return await analyticsRepository.GetBestMonthAsync();
        }
    }
}
