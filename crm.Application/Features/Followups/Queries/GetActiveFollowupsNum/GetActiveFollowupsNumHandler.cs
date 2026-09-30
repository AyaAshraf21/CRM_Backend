using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Followups.Queries.GetActiveFollowupsNum
{
    public class GetActiveFollowupsNumHandler : IRequestHandler<GetActiveFollowupsNumQuery, int>
    {
        private readonly IFollowupRepository followupRepository;

        public GetActiveFollowupsNumHandler(IFollowupRepository followupRepository)
        {
            this.followupRepository = followupRepository;
        }

        public async Task<int> Handle(GetActiveFollowupsNumQuery request, CancellationToken cancellationToken)
        {
            return await followupRepository.GetActiveFollowupsNumAsync();
        }
    }
}
