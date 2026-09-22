using crm.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Analytics.Queries.GetBestPlatform
{
    public record GetBestPlatformQuery : IRequest<string>;
}
