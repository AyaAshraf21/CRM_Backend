using AutoMapper;
using crm.Application.Features.Governates.DTOs;
using crm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Governates.Queries.GetAllGovernates
{
    public class GetAllGovernatesHandler : IRequestHandler<GetAllGovernatesQuery, List<GovernorateResponseDTO>>
    {
        private readonly IGovernorateRepository governorateRepository;
        private IMapper mapper;

        public GetAllGovernatesHandler(IGovernorateRepository governorateRepository, IMapper mapper)
        {
            this.governorateRepository = governorateRepository;
            this.mapper = mapper;
        }

        public async Task<List<GovernorateResponseDTO>> Handle(GetAllGovernatesQuery request, CancellationToken cancellationToken)
        {
            var governorates = await governorateRepository.GetAllGovernoratesAsync();
            return mapper.Map<List<GovernorateResponseDTO>>(governorates);
        }
    }
}
