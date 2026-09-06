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

namespace crm.Application.Features.Followups.Commands.CreateFollowup
{
    public class CreateFollowupHandler : IRequestHandler<CreateFollowupCommand, FollowupResponseDTO>
    {
        private readonly IFollowupRepository followupRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateFollowupHandler(IFollowupRepository followupRepository, ICustomerRepository customerRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.followupRepository = followupRepository;
            this.customerRepository = customerRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<FollowupResponseDTO> Handle(CreateFollowupCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetCustomerByIdAsync(request.customerId);
            if(customer == null)
            {
                throw new NotFoundException("Customer", request.customerId);
            }
            if (!Enum.IsDefined(typeof(Platform), request.followupDTO.Platform))
            {
                throw new BadRequestException("Invalid Platform Value");
            }
            if (!Enum.IsDefined(typeof(PaymentType), request.followupDTO.PaymentType))
            {
                throw new BadRequestException("Invalid Payment Type Value");
            }
            if (!Enum.IsDefined(typeof(DeviceCondition), request.followupDTO.DeviceCondition))
            {
                throw new BadRequestException("Invalid Device Condition Value");
            }
            if (!Enum.IsDefined(typeof(OperationType), request.followupDTO.OperationType))
            {
                throw new BadRequestException("Invalid Operation Type Value");
            }

            var followup = mapper.Map<Followup>(request.followupDTO);
            followup.CustomerId = request.customerId;
            followup.StatusHistory.Add(new StatusFollowup
            {
                Status = request.followupDTO.Status,
                ChangedAt = DateTime.UtcNow
            });
            followupRepository.CreateFollowup(followup);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<FollowupResponseDTO>(followup); 
        }
    }
}
