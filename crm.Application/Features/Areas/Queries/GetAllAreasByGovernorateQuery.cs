using crm.Application.Features.Areas.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Areas.Queries
{
    public record GetAllAreasByGovernorateQuery(int governorateId) : IRequest<List<AreaResponseDTO>>;
}
