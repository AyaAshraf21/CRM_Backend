using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Followups.Queries.GetFollowupsNum
{
    public class GetFollowupsNumHandler : IRequestHandler<GetFollowupsNumQuery, int>
    {
        private readonly IFollowupRepository followupRepository;

        public GetFollowupsNumHandler(IFollowupRepository followupRepository)
        {
            this.followupRepository = followupRepository;
        }

        public Task<int> Handle(GetFollowupsNumQuery request, CancellationToken cancellationToken)
        {
            return followupRepository.GetFollowupsNumAsync();
        }
    }
}
