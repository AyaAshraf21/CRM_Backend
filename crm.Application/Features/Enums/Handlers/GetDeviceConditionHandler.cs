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
    public class GetDeviceConditionHandler : IRequestHandler<GetDeviceConditionQuery, List<EnumResponseDTO>>
    {
        public Task<List<EnumResponseDTO>> Handle(GetDeviceConditionQuery request, CancellationToken cancellationToken)
        {
            var devicesConditions = Enum.GetValues<DeviceCondition>()
                                                .Select(x => new EnumResponseDTO
                                                {
                                                    Id = (int)x,
                                                    Name = x.ToString()
                                                }).ToList();
            return Task.FromResult(devicesConditions);
        }
    }
}
