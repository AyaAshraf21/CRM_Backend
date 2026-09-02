using crm.Application.Exceptions;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteCustomerHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetCustomerByIdAsync(request.id);
            if (customer == null) 
            {
                throw new NotFoundException("Customer", request.id);
            }
            if (customer.IsDeleted)
            {
                throw new BadRequestException($"Customer with id = {request.id} Already Deleted");
            }
            customer.IsDeleted = true;
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
