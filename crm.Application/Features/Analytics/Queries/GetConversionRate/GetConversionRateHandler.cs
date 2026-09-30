using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetConversionRate
{
    public class GetConversionRateHandler : IRequestHandler<GetConversionRateQuery, double>
    {
        private readonly IFollowupRepository followupRepository;
        private readonly IAnalyticsRepository analyticsRepository;

        public GetConversionRateHandler(IFollowupRepository followupRepository, IAnalyticsRepository analyticsRepository)
        {
            this.followupRepository = followupRepository;
            this.analyticsRepository = analyticsRepository;
        }
     
        public async Task<double> Handle(GetConversionRateQuery request, CancellationToken cancellationToken)
        {
            var followupNum = await followupRepository.GetFollowupsNumAsync();
            var salesNum = await analyticsRepository.GetSalesNumAsync();

            return ((double)salesNum / followupNum) * 100;
        }
    }
}
