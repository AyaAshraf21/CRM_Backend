using crm.Application.Features.Followups.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Followups.Queries.GetAllFollowups
{
    public record GetAllFollowupsQuery(FollowupQueryParameters followupQueryParameters): IRequest<FollowupPaginationResponseDTO>;
}
