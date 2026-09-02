using crm.Application.Features.Enums.DTOs;
using crm.Application.Features.Enums.Queries;
using crm.Domain.Entities;
using crm.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Enums.Handlers
{
    public class GetStatusHandler : IRequestHandler<GetStatusQuery, List<EnumResponseDTO>>
    {
        public Task<List<EnumResponseDTO>> Handle(GetStatusQuery request, CancellationToken cancellationToken)
        {
            var status = Enum.GetValues<Status>()
                            .Select(x => new EnumResponseDTO
                            {
                                Id = (int)x,
                                Name = x.ToString()
                            }).ToList();
            return Task.FromResult(status);
        }
    }
}
