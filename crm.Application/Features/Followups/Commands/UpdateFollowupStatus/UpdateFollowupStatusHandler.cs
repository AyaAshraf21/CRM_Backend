using AutoMapper;
using crm.Application.Exceptions;
using crm.Application.Features.Followups.DTOs;
using crm.Application.Interfaces;
using crm.Domain.Entities;
using crm.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Followups.Commands.UpdateFollowupStatus
{
    public class UpdateFollowupStatusHandler : IRequestHandler<UpdateFollowupStatusCommand, FollowupResponseDTO>
    {
        private readonly IFollowupRepository followupRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateFollowupStatusHandler(IFollowupRepository followupRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.followupRepository = followupRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<FollowupResponseDTO> Handle(UpdateFollowupStatusCommand request, CancellationToken cancellationToken)
        {
            var followup = await followupRepository.GetFollowupByIdAsync(request.followupId);
            if (followup == null)
            {
                throw new NotFoundException("Followup",  request.followupId);
            }
            if (!Enum.IsDefined(typeof(Status), request.status))
            {
                throw new BadRequestException("Invalid Status Value");
            }
            followup.StatusHistory.Add(new StatusFollowup
            {
                Status = request.status,
                ChangedAt = DateTime.UtcNow
            });
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<FollowupResponseDTO>(followup);
        }
    }
}
