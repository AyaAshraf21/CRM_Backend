using crm.Application.Features.Analytics.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetCustomersPerMonth
{
    public class GetCustomersPerMonthHandler : IRequestHandler<GetCustomersPerMonthQuery, List<MonthlyCustomerCountDTO>>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetCustomersPerMonthHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<List<MonthlyCustomerCountDTO>> Handle(GetCustomersPerMonthQuery request, CancellationToken cancellationToken)
        {
            return await analyticsRepository.GetCustomersPerMonthAsync();
        }
    }
}
