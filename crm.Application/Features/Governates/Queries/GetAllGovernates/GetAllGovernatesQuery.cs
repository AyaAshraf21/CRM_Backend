using crm.Application.Features.Governates.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Governates.Queries.GetAllGovernates
{
    public record GetAllGovernatesQuery : IRequest<List<GovernorateResponseDTO>>;
}
