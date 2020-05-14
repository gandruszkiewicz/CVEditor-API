using AutoMapper;
using CVEditorAPI.Data;
using CVEditorAPI.Data.Dtos;
using CVEditorAPI.Data.Dtos.Requests.ResumeComponents;
using CVEditorAPI.Data.Model;
using CVEditorAPI.Extensions;
using CVEditorAPI.Services;
using CVEditorAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CVEditorAPI.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ResumeController: Controller
    {

        private readonly IResumeService _resumeService;
        private readonly IMapper _mapper;

        public ResumeController(IResumeService resume, IMapper mapper)
        {
            this._resumeService = resume;
            this._mapper = mapper;
        }

        [HttpGet(Concracts.V1.ApiRoutes.Resume.GetAll)]
        public IActionResult GetAll()
        {
            var resumes =
                this._resumeService.GetWhere(x => x.UserId == this.User.GetUserId());

            return Ok(resumes);
        }

        [HttpPost(Concracts.V1.ApiRoutes.Resume.Post)]
        public async Task<IActionResult> Post([FromBody] ResumeDto resumeDto)
        {
            var entity = _mapper.Map<Resume>(resumeDto);

            entity.UserId = this.User.GetUserId();

            var result = await _resumeService.CreateAsync(entity);

            return this.Ok(result);
        }

        [HttpPut(Concracts.V1.ApiRoutes.Resume.Put)]
        public async Task<IActionResult> Put([FromBody] PutResumeDto resumeDto)
        {
            var entity = _mapper.Map<Resume>(resumeDto);
            entity.UserId = this.User.GetUserId();
            var result = await _resumeService.UpdateAsync(entity);

            return this.Ok(result);
        }

        [HttpDelete(Concracts.V1.ApiRoutes.Resume.Delete)]
        public async Task<IActionResult> Delete(int resumeId)
        {
            var entity = this._resumeService.GetFirstOrDefault(x => x.Id == resumeId);

            var result = await _resumeService.DeleteAsync(entity);

            return this.Ok(result);
        }
    }
}
