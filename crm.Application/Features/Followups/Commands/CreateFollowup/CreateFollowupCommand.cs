using crm.Application.Features.Followups.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Followups.Commands.CreateFollowup
{
    public record CreateFollowupCommand(int customerId ,FollowupDTO followupDTO) : IRequest<FollowupResponseDTO>;
}