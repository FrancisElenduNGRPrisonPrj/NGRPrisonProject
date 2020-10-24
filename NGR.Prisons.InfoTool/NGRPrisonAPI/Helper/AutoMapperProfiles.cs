using AutoMapper;
using NGRPrisonAPI.Dto;
using NGRPrisonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGRPrisonAPI.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Prison, PrisonDto>()
                .ForMember(dest => dest.StateName, opt => opt.
                MapFrom(src => src.State.StateName));

            CreateMap<State, StateDto>()
                .ForMember(dest => dest.Prisons, opt=>opt.Ignore()).ReverseMap()
                .ForMember(dest => dest.Inmates, opt => opt.Ignore()).ReverseMap();

            CreateMap<Inmate, InmateDto>()
                .ForMember(dest => dest.StateOfOrigin, opt => opt.
                MapFrom(src => src.State.StateName))
                .ForMember(dest => dest.PrisonName, opt => opt.
                MapFrom(src => src.Prison.PrisonName));
        }

    }
}
