using crm.Application.Features.Analytics.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetCustomersPerMonth
{
    public record GetCustomersPerMonthQuery : IRequest<List<MonthlyCustomerCountDTO>>;
}
