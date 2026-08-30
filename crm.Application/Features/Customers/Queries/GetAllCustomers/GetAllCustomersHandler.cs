using AutoMapper;
using crm.Application.Features.Customers.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, CustomerPaginationResponseDTO>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public GetAllCustomersHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }
        public async Task<CustomerPaginationResponseDTO> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = await customerRepository.GetAllCustomersAsync(request.customerQueryParameters);
            var customers = mapper.Map<List<CustomerResponseDTO>>(result.Item1);
            var totalCount = result.totalCount;

            return new CustomerPaginationResponseDTO
            {
                Items = customers,
                TotalCount = totalCount,
                PageNumber = request.customerQueryParameters.Page,
                PageSize = request.customerQueryParameters.PerPage
            };
        }
    }
}
