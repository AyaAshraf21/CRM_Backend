using AutoMapper;
using crm.Application.Exceptions;
using crm.Application.Features.Customers.DTOs;
using crm.Application.Interfaces;
using crm.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, CustomerResponseDTO>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IAreaRepository areaRepository;
        private readonly ITagRepository tagRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateCustomerHandler(ICustomerRepository customerRepository, IAreaRepository areaRepository, ITagRepository tagRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.areaRepository = areaRepository;
            this.tagRepository = tagRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CustomerResponseDTO> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetCustomerByIdAsync(request.id);
            if(customer == null)
            {
                throw new NotFoundException("Customer",request.id);
            }
            if (customer.Phone != request.customerDTO.Phone) {
                bool isPhoneExist = await customerRepository.IsPhoneNumberExistsAsync(request.customerDTO.Phone);
                if (isPhoneExist)
                {
                    throw new AlreadyExistsException("Phone");
                }
            }
            if (customer.AreaId != request.customerDTO.AreaId || customer.Area.GovernorateId != request.customerDTO.GovernorateId) 
            {
                bool isAreaOrGovernorateValid = await areaRepository.IsAreaIdValid(request.customerDTO.AreaId, request.customerDTO.GovernorateId);
                if (!isAreaOrGovernorateValid)
                {
                    throw new BadRequestException("The specified governorate or area is invalid");
                }
            }
            if (customer.TagId != request.customerDTO.TagId)
            {
                bool isTagValid = await tagRepository.IsTagExistsById(request.customerDTO.TagId);
                if (!isTagValid)
                {
                    throw new NotFoundException("Tag", request.customerDTO.TagId);
                }
            }
            mapper.Map(request.customerDTO, customer);
            customerRepository.UpdateCustomer(customer);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<CustomerResponseDTO>(customer);
        }
    }
}
