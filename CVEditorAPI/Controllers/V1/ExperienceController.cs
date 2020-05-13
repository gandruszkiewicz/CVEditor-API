using AutoMapper;
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
    public class ExperienceController: Controller
    {
        private readonly IExperience _experienceService;
        private readonly IMapper _mapper;

        public ExperienceController(
            IExperience professionalExperienceService,
            IMapper mapper)
        {
            _experienceService = professionalExperienceService;
            this._mapper = mapper;
        }

        [HttpGet(Concracts.V1.ApiRoutes.Experience.GetAll)]
        public IActionResult GetAll(int resumeId)
        {
            var personalDatas =
                this._experienceService.GetAll(resumeId);

            return Ok(personalDatas);
        }

        [HttpPost(Concracts.V1.ApiRoutes.Experience.Post)]
        public async Task<IActionResult> Post([FromBody] PostExperienceDto request)
        {
            var userId = HttpContext.User.GetUserId();
            var entity = _mapper.Map<Experience>(request);

            var result = await _experienceService.CreateAsync(entity);

            return this.Ok(result);
        }

        [HttpPut(Concracts.V1.ApiRoutes.Experience.Put)]
        public async Task<IActionResult> Put([FromBody] PutExperienceDto experienceDto)
        {
            var entity = _mapper.Map<Experience>(experienceDto);

             var result = await _experienceService.Update(entity);

            return this.Ok(result);
        }

        [HttpDelete(Concracts.V1.ApiRoutes.Experience.Delete)]
        public async Task<IActionResult> Delete(int experienceId)
        {
            var entity = this._experienceService.Get(experienceId);

            var result = await _experienceService.Delete(entity);

            return this.Ok(result);
        }

    }
}
