using crm.Application.Features.Enums.DTOs;
using crm.Application.Features.Enums.Queries;
using crm.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Enums.Handlers
{
    public class GetPaymentTypeHandler : IRequestHandler<GetPaymentTypeQuery, List<EnumResponseDTO>>
    {
        public Task<List<EnumResponseDTO>> Handle(GetPaymentTypeQuery request, CancellationToken cancellationToken)
        {
            var paymentTypes = Enum.GetValues<PaymentType>()
                                                .Select(x => new EnumResponseDTO
                                                {
                                                    Id = (int)x,
                                                    Name = x.ToString()
                                                }).ToList();
            return Task.FromResult(paymentTypes);
        }
    }
}
