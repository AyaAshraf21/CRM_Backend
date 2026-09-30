using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetTopDevice
{
    public class GetTopDeviceHandler : IRequestHandler<GetTopDeviceQuery, string>
    {
        private IAnalyticsRepository analyticsRepository;

        public GetTopDeviceHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<string> Handle(GetTopDeviceQuery request, CancellationToken cancellationToken)
        {
            return await analyticsRepository.GetTopDeviceAsync();
        }
    }
}
