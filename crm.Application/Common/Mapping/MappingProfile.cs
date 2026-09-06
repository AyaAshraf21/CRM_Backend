using AutoMapper;
using crm.Application.Features.Areas.DTOs;
using crm.Application.Features.Customers.DTOs;
using crm.Application.Features.Followups.DTOs;
using crm.Application.Features.Governates.DTOs;
using crm.Application.Features.Tags.DTOs;
using crm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Governorate, GovernorateResponseDTO>();

            CreateMap<Area, AreaResponseDTO>();

            CreateMap<Tag, TagResponseDTO>();

            CreateMap<Customer, CustomerResponseDTO>()
                .ForMember(
                    dest => dest.GovernorateName,
                    opt => opt.MapFrom(src => src.Area.Governorate.Name))
                .ForMember(
                    dest => dest.AreaName,
                    opt => opt.MapFrom(src => src.Area.Name))
                .ForMember(
                    dest => dest.TagName,
                    opt => opt.MapFrom(src => src.Tag != null ? src.Tag.Name : null));

            CreateMap<CustomerDTO, Customer>();

            CreateMap<Followup, FollowupResponseDTO>()
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.StatusHistory
                                                .OrderByDescending(s => s.ChangedAt)
                                                .Select(s => s.Status.ToString())
                                                .FirstOrDefault()))
                .ForMember(
                    dest => dest.PaymentType,
                    opt => opt.MapFrom(src => src.PaymentType.ToString())
                )
                .ForMember(
                    dest => dest.OperationType,
                    opt => opt.MapFrom(src => src.OperationType.ToString())
                )
                .ForMember(
                    dest => dest.DeviceCondition,
                    opt => opt.MapFrom(src => src.DeviceCondition.ToString())
                )
                .ForMember(
                    dest => dest.Platform,
                    opt => opt.MapFrom(src => src.Platform.ToString())
                )
                .ForMember(
                    dest => dest.Customer,
                    opt => opt.MapFrom(src => src.Customer)
                );

            CreateMap<FollowupDTO, Followup>();
        }
    }
}
