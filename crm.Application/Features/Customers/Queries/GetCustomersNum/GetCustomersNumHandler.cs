using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Customers.Queries.GetCustomerNum
{
    public class GetCustomersNumHandler : IRequestHandler<GetCustomersNumQuery, int>
    {
        private readonly ICustomerRepository customerRepository;

        public GetCustomersNumHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<int> Handle(GetCustomersNumQuery request, CancellationToken cancellationToken)
        {
            return await customerRepository.GetCustomersNumAsync();
        }
    }
}
