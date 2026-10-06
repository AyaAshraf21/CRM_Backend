using crm.Application.Features.Analytics.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetCustomerTagAnalytics
{
    public record GetCustomerTagAnalyticsQuery : IRequest<List<CustomerTagAnalyticsDTO>>;
}
