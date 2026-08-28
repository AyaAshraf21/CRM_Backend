using AutoMapper;
using crm.Application.Exceptions;
using crm.Application.Features.Areas.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Areas.Queries
{
    public class GetAllAreasByGovernorateHandler : IRequestHandler<GetAllAreasByGovernorateQuery, List<AreaResponseDTO>>
    {
        private readonly IAreaRepository areaRepository;
        private readonly IGovernorateRepository governorateRepository;
        private readonly IMapper mapper; 

        public GetAllAreasByGovernorateHandler(IAreaRepository areaRepository , IMapper mapper, IGovernorateRepository governorateRepository)
        {
            this.areaRepository = areaRepository;
            this.governorateRepository = governorateRepository;
            this.mapper = mapper;
        }

        public async Task<List<AreaResponseDTO>> Handle(GetAllAreasByGovernorateQuery request, CancellationToken cancellationToken)
        {
            bool isGovernorateExists = await governorateRepository.isGovernorateExistsById(request.governorateId);
            if(!isGovernorateExists)
            {
                throw new NotFoundException("Governorate", request.governorateId);
            }
            var areas = await areaRepository.GetAllAreasByGovernorateAsync(request.governorateId);
            return mapper.Map<List<AreaResponseDTO>>(areas);
        }
    }
}
