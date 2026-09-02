using crm.Application.Features.Enums.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Enums.Queries
{
    public record GetOperationTypeQuery : IRequest<List<EnumResponseDTO>>;
}
