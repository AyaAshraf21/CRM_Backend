using crm.Application.Features.Customers.Queries.GetAllCustomers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Customers.Validators
{
    public class CustomerQueryParametersValidator : AbstractValidator<GetAllCustomersQuery>
    {
        public CustomerQueryParametersValidator()
        {
            RuleFor(x => x.customerQueryParameters.Page)
                .GreaterThan(0)
                .WithMessage("Page Number must Greater than 0");

            RuleFor(x => x.customerQueryParameters.PerPage)
                .InclusiveBetween(1, 100);

            RuleFor(x => x.customerQueryParameters.GovernorateId)
                .GreaterThan(0);

            RuleFor(x => x.customerQueryParameters.AreaId)
                .GreaterThan(0);

            RuleFor(x => x.customerQueryParameters.TagId)
                .GreaterThan(0);

            RuleFor(x => x.customerQueryParameters.Search)
                .MaximumLength(100)
                .When(x => !string.IsNullOrWhiteSpace(x.customerQueryParameters.Search));
        }
    }
}
