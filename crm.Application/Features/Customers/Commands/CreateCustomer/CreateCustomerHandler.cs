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

namespace crm.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerResponseDTO>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IAreaRepository areaRepository;
        private readonly ITagRepository tagRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateCustomerHandler(ICustomerRepository customerRepository,IAreaRepository areaRepository, ITagRepository tagRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.areaRepository = areaRepository;
            this.tagRepository = tagRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<CustomerResponseDTO> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            bool isPhoneExist = await customerRepository.IsPhoneNumberExists(request.customerDTO.Phone);
            if (isPhoneExist)
            {
                throw new AlreadyExistsException("Phone Number");
            }
            bool areAreaAndGovernorateValid = await areaRepository.IsAreaIdValid(request.customerDTO.AreaId, request.customerDTO.GovernorateId);
            if (!areAreaAndGovernorateValid)
            {
                throw new BadRequestException("The specified governorate or area is invalid");
            }
            bool isTagValid = await tagRepository.IsTagExistsById(request.customerDTO.TagId);
            if (!isTagValid)
            {
                throw new NotFoundException("Tag", request.customerDTO.TagId);
            }
            var customer = mapper.Map<Customer>(request.customerDTO);
            customerRepository.CreateCustomer(customer);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<CustomerResponseDTO>(customer);
        }
    }
}
