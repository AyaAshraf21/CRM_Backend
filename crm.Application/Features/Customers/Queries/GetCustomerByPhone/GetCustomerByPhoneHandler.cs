using AutoMapper;
using crm.Application.Exceptions;
using crm.Application.Features.Customers.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Customers.Queries.GetCustomerByPhone
{
    public class GetCustomerByPhoneHandler : IRequestHandler<GetCustomerByPhoneQuery, CustomerResponseDTO>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;
        public GetCustomerByPhoneHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public async Task<CustomerResponseDTO> Handle(GetCustomerByPhoneQuery request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetCustomerByPhoneAsync(request.phone);
            if(customer == null)
            {
                throw new NotFoundException("Customer", request.phone);
            }
            return mapper.Map<CustomerResponseDTO>(customer);
        }
    }
}
