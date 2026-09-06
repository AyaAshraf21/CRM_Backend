using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Followups.Commands.DeleteFollowup
{
    public record DeleteFollowupCommand(int id) : IRequest;
}
