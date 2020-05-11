using CVEditorAPI.Data.Dtos.Requests;
using CVEditorAPI.Data.Model;
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
        private readonly string userId;

        public ProfessionalExperienceController(
            IProfessionalExperienceService professionalExperienceService)
        {
            _professionalExperienceService = professionalExperienceService;
            this.userId = HttpContext.User.GetUserId();
        }

        [HttpGet(Concracts.V1.ApiRoutes.ProfessionalExperience.GetAll)]
        public IActionResult GetAll()
        {
            var personalDatas =
                this._professionalExperienceService.GetAll();

            return Ok(personalDatas);
        }

        [HttpPost(Concracts.V1.ApiRoutes.ProfessionalExperience.Post)]
        public async Task<IActionResult> Post([FromBody] ProfessionalExperiencePostRequest request)
        {
            var entity = new ProfessionalExperience()
            {
                CompanyName = request.CompanyName,
                City = request.City,
                Position = request.Position,
                Description = request.Description,
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
                ResumeId = request.ResumeId
            };

            var result = await _professionalExperienceService.CreateAsync(entity);

            return this.Ok(result);
        }
    }
}
