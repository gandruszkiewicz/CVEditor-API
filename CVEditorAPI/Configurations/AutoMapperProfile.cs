using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CVEditorAPI.Data.Dtos.Requests;
using CVEditorAPI.Data.Dtos.Requests.ResumeComponents;
using CVEditorAPI.Data.Model;
using CVEditorAPI.Data.Model.ResumeComponents;

namespace CVEditorAPI.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProfessionalExperiencePostRequest, ProfessionalExperience>();
            CreateMap<QualificationPostRequest, Qualification>();
            CreateMap<ResumePostRequest,Resume>();
        }
    }
}
