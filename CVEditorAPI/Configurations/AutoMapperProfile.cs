using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CVEditorAPI.Data.Dtos;
using CVEditorAPI.Data.Dtos.Requests.ResumeComponents;
using CVEditorAPI.Data.Model;
using CVEditorAPI.Data.Model.ResumeCompoments;
using CVEditorAPI.Data.Model.ResumeComponents;

namespace CVEditorAPI.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PostExperienceDto, Experience>();
            CreateMap<PutExperienceDto, Experience>();

            CreateMap<PostQualificationDto, Qualification>();
            CreateMap<PutQualificationDto, Qualification>();

            CreateMap<PostSkillDto, Skill>();
            CreateMap<PutSkillDto, Skill>();

            CreateMap<ResumeDto, Resume>();
            CreateMap<PutResumeDto, Resume>();
        }
    }
}
