using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Followups.Queries.GetFollowupsNum
{
    public record GetFollowupsNumQuery : IRequest<int>;
}
