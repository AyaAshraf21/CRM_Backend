using crm.Application.Features.Customers.Commands.UpdateCustomer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Customers.Validators
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.customerDTO.Phone)
                .NotEmpty()
                .Matches(@"^01[0125][0-9]{8}$")
                .WithMessage("Invalid phone number");

            RuleFor(x => x.customerDTO.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.customerDTO.GovernorateId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.customerDTO.AreaId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.customerDTO.TagId)
                .GreaterThan(0);
        }
    }
}
