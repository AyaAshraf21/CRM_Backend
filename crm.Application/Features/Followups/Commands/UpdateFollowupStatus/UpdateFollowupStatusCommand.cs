using crm.Application.Features.Followups.DTOs;
using crm.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Followups.Commands.UpdateFollowupStatus
{
    public record UpdateFollowupStatusCommand(int followupId, Status status) : IRequest<FollowupResponseDTO>;
}
