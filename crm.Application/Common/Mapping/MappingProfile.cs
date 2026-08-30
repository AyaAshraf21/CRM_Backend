using AutoMapper;
using crm.Application.Features.Areas.DTOs;
using crm.Application.Features.Customers.DTOs;
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
                
                
        }
    }
}
