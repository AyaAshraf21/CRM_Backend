using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetTopGovernorate
{
    public class GetTopGovernorateHandler : IRequestHandler<GetTopGovernorateQuery, string>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetTopGovernorateHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<string> Handle(GetTopGovernorateQuery request, CancellationToken cancellationToken)
        {
            return await analyticsRepository.GetTopGovernorateAsync();
        }
    }
}
