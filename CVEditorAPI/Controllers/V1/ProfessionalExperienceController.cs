using AutoMapper;
using CVEditorAPI.Data.Dtos.Requests;
using CVEditorAPI.Data.Dtos.Requests.ResumeComponents;
using CVEditorAPI.Data.Model;
using CVEditorAPI.Data.Model.ResumeComponents;
using CVEditorAPI.Extensions;
using CVEditorAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CVEditorAPI.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProfessionalExperienceController: Controller
    {
        private readonly IProfessionalExperienceService _professionalExperienceService;
        private readonly IMapper _mapper;

        public ProfessionalExperienceController(
            IProfessionalExperienceService professionalExperienceService,
            IMapper mapper)
        {
            _professionalExperienceService = professionalExperienceService;
            this._mapper = mapper;
        }

        [HttpGet(Concracts.V1.ApiRoutes.ProfessionalExperience.GetAll)]
        public IActionResult GetAll(int resumeId)
        {
            var personalDatas =
                this._professionalExperienceService.GetAll(resumeId);

            return Ok(personalDatas);
        }

        [HttpPost(Concracts.V1.ApiRoutes.ProfessionalExperience.Post)]
        public async Task<IActionResult> Post([FromBody] ProfessionalExperiencePostRequest request)
        {
            var userId = HttpContext.User.GetUserId();
            var entity = _mapper.Map<ProfessionalExperience>(request);

            var result = await _professionalExperienceService.CreateAsync(entity);

            return this.Ok(result);
        }

    }
}
