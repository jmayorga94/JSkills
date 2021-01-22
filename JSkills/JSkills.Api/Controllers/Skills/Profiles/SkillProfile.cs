using AutoMapper;
using JSkills.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSkills.Api.Controllers.Skills.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, SkillDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(s => s.IsActive));
        }
    }
}
