using AutoMapper;
using crm.Application.Exceptions;
using crm.Application.Features.Followups.DTOs;
using crm.Application.Interfaces;
using crm.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Followups.Commands.UpdateFollowup
{
    public class UpdateFollowupHandler : IRequestHandler<UpdateFollowupCommand, FollowupResponseDTO>
    {
        private readonly IFollowupRepository followupRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateFollowupHandler(IFollowupRepository followupRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.followupRepository = followupRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<FollowupResponseDTO> Handle(UpdateFollowupCommand request, CancellationToken cancellationToken)
        {
            var followup = await followupRepository.GetFollowupByIdAsync(request.id);
            if(followup == null)
            {
                throw new NotFoundException("Followup", request.id);
            }
            if (followup.Platform != request.followupDTO.Platform && !Enum.IsDefined(typeof(Platform), request.followupDTO.Platform))
            {
                throw new BadRequestException("Invalid Platform Value");
            }
            if (followup.PaymentType != request.followupDTO.PaymentType && !Enum.IsDefined(typeof(PaymentType), request.followupDTO.PaymentType))
            {
                throw new BadRequestException("Invalid Payment Type Value");
            }
            if (followup.DeviceCondition != request.followupDTO.DeviceCondition && !Enum.IsDefined(typeof(DeviceCondition), request.followupDTO.DeviceCondition))
            {
                throw new BadRequestException("Invalid Device Condition Value");
            }
            if (followup.OperationType != request.followupDTO.OperationType && !Enum.IsDefined(typeof(OperationType), request.followupDTO.OperationType))
            {
                throw new BadRequestException("Invalid Operation Type Value");
            }

            mapper.Map(request.followupDTO, followup);
            followupRepository.UpdateFollowup(followup);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<FollowupResponseDTO>(followup);
        }
    }
}
