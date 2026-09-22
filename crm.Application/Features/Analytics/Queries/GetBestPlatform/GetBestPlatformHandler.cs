using crm.Application.Interfaces;
using crm.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetBestPlatform
{
    public class GetBestPlatformHandler : IRequestHandler<GetBestPlatformQuery, string>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetBestPlatformHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<string> Handle(GetBestPlatformQuery request, CancellationToken cancellationToken)
        {
            var platform = await analyticsRepository.GetBestPlatformAsync();
            return platform.ToString();
        }
    }
}
