using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Customers.Queries.GetCustomerNum
{
    public record GetCustomersNumQuery : IRequest<int>;
}
