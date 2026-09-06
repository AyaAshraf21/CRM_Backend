using crm.Application.Features.Followups.Commands.CreateFollowup;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Followups.Validators
{
    public class CreateFollowupValidator : AbstractValidator<CreateFollowupCommand>
    {
        public CreateFollowupValidator()
        {
            RuleFor(x => x.followupDTO.DeviceType)
                .NotNull()
                .NotEmpty()
                .WithMessage("Device Type must not be null or empty")
                .MaximumLength(100)
                .WithMessage("Device Type Length must not exceed 100 charchaters");

            RuleFor(x => x.followupDTO.Platform)
                .NotNull()
                .IsInEnum()
                .WithMessage("Invalid Platform value");

            RuleFor(x => x.followupDTO.PaymentType)
                .NotNull()
                .IsInEnum()
                .WithMessage("Invalid Payment Type value");

            RuleFor(x => x.followupDTO.DeviceCondition)
                .NotNull()
                .IsInEnum()
                .WithMessage("Invalid Device Condition value");

            RuleFor(x => x.followupDTO.OperationType)
                .NotNull()
                .IsInEnum()
                .WithMessage("Invalid Operation Type value");

            RuleFor(x => x.followupDTO.Notes)
                .MaximumLength(250)
                .WithMessage("Notes lenght must not exceed 250 characters");
        }
    }
}
