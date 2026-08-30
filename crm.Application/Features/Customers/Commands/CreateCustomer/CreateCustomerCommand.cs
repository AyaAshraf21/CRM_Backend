using crm.Application.Features.Customers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Customers.Commands.CreateCustomer
{
    public record CreateCustomerCommand(CustomerDTO customerDTO) : IRequest<CustomerResponseDTO>;
}
