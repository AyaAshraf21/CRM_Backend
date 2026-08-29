using AutoMapper;
using crm.Application.Features.Tags.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Tags.Queries.GetAllTags
{
    public class GetAllTagsHandler : IRequestHandler<GetAllTagsQuery, List<TagResponseDTO>>
    {
        private readonly ITagRepository tagRepository;
        private readonly IMapper mapper;

        public GetAllTagsHandler(ITagRepository tagRepository, IMapper mapper)
        {
            this.tagRepository = tagRepository;
            this.mapper = mapper;
        }
        public async Task<List<TagResponseDTO>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await tagRepository.GetAllTagsAsync();
            return mapper.Map<List<TagResponseDTO>>(tags);
        }
    }
}
