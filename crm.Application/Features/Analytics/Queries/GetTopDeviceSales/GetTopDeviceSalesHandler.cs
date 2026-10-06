using crm.Application.Features.Analytics.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetTopDeviceSales
{
    public class GetTopDeviceSalesHandler : IRequestHandler<GetTopDeviceSalesQuery, List<TopDeviceSalesDTO>>
    {
        private readonly IAnalyticsRepository analyticsRepository;

        public GetTopDeviceSalesHandler(IAnalyticsRepository analyticsRepository)
        {
            this.analyticsRepository = analyticsRepository;
        }

        public async Task<List<TopDeviceSalesDTO>> Handle(GetTopDeviceSalesQuery request, CancellationToken cancellationToken)
        {
            return await analyticsRepository.GetTopDeviceSalesAsync();
        }
    }
}
