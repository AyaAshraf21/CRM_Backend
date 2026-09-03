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

namespace crm.Application.Features.Customers.Commands.RestoreCustomer
{
    public class RestoreCustomerHandler : IRequestHandler<RestoreCustomerCommand, CustomerResponseDTO>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RestoreCustomerHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<CustomerResponseDTO> Handle(RestoreCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetCustomerByIdWithDeletedAsync(request.id);
            if (customer == null)
            {
                throw new NotFoundException("Customer", request.id);
            }
            if(customer.IsDeleted == false)
            {
                throw new AlreadyExistsException("Customer");
            }
            customer.IsDeleted = false;
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<CustomerResponseDTO>(customer);
        }
    }
}
