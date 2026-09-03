using AutoMapper;
using crm.Application.Features.Followups.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Followups.Queries.GetAllFollowups
{
    public class GetAllFollowupsHandler : IRequestHandler<GetAllFollowupsQuery,FollowupPaginationResponseDTO>
    {
        private readonly IFollowupRepository followupRepository;
        private readonly IMapper mapper;
        
        public GetAllFollowupsHandler(IFollowupRepository followupRepository,IMapper mapper)
        {
            this.followupRepository = followupRepository;
            this.mapper = mapper;
        }

        public async Task<FollowupPaginationResponseDTO> Handle(GetAllFollowupsQuery request, CancellationToken cancellationToken)
        {
            var result = await followupRepository.GetAllFollowupsAsync(request.followupQueryParameters);
            var followups = mapper.Map<List<FollowupResponseDTO>>(result.Item1);
            var totalCount = result.totalCount;
            return new FollowupPaginationResponseDTO
            {
                Items = followups,
                PageNumber = request.followupQueryParameters.Page,
                PageSize = request.followupQueryParameters.PerPage,
                TotalCount = totalCount
            };
        }
    }
}
