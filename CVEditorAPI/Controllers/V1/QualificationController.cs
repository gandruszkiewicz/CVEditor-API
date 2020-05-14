using AutoMapper;
using CVEditorAPI.Data.Dtos.Requests.ResumeComponents;
using CVEditorAPI.Data.Model.ResumeComponents;
using CVEditorAPI.Services;
using CVEditorAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CVEditorAPI.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class QualificationController: Controller
    {
        private readonly IQualificationService _qualificationService;
        private readonly IMapper _mapper;

        public QualificationController(IQualificationService qualificationService, IMapper mapper)
        {
            this._qualificationService = qualificationService;
            this._mapper = mapper;
        }

        [HttpGet(Concracts.V1.ApiRoutes.Qualification.GetAll)]
        public IActionResult GetAll(int resumeId)
        {
            var qualifications =
                this._qualificationService.GetWhere(x => x.ResumeId == resumeId);

            return Ok(qualifications);
        }

        [HttpPost(Concracts.V1.ApiRoutes.Qualification.Post)]
        public async Task<IActionResult> Post([FromBody] PostQualificationDto qualificationDto)
        {
            var entity = _mapper.Map<Qualification>(qualificationDto);

            var result = await _qualificationService.CreateAsync(entity);

            return this.Ok(result);
        }

        [HttpPut(Concracts.V1.ApiRoutes.Qualification.Put)]
        public async Task<IActionResult> Put([FromBody] PutQualificationDto qualificationDto)
        {
            var entity = _mapper.Map<Qualification>(qualificationDto);

            var result = await _qualificationService.UpdateAsync(entity);

            return this.Ok(result);
        }

        [HttpDelete(Concracts.V1.ApiRoutes.Qualification.Delete)]
        public async Task<IActionResult> Delete(int qualificationId)
        {
            var entity = this._qualificationService.GetFirstOrDefault(x => x.Id == qualificationId);

            var result = await _qualificationService.DeleteAsync(entity);

            return this.Ok(result);
        }

    }
}
