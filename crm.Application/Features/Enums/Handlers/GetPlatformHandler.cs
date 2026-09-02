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
    public class GetPlatformHandler : IRequestHandler<GetPlatformQuery, List<EnumResponseDTO>>
    {
        public Task<List<EnumResponseDTO>> Handle(GetPlatformQuery request, CancellationToken cancellationToken)
        {
            var platfroms = Enum.GetValues<Platform>()
                                            .Select(x => new EnumResponseDTO
                                            {
                                                Id = (int)x,
                                                Name = x.ToString()
                                            }).ToList();
            return Task.FromResult(platfroms);
        }
    }
}
