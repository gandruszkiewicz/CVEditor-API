using CVEditorAPI.Data;
using CVEditorAPI.Data.Dtos;
using CVEditorAPI.Data.Dtos.Requests;
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

        private readonly IResumeService _personalDataService;
        private readonly string _userId;

        public ResumeController(IResumeService personalDataService)
        {
            _personalDataService = personalDataService;
            this._userId = HttpContext.User.GetUserId();
        }

        [HttpGet(Concracts.V1.ApiRoutes.Resumes.GetAll)]
        public IActionResult GetAll()
        {
            var personalDatas = 
                this._personalDataService.GetAll();

            return Ok(personalDatas);
        }

        [HttpPost(Concracts.V1.ApiRoutes.Resumes.Post)]
        public async Task<IActionResult> Post([FromBody] ResumePostRequest request)
        {
            var entity = new Resume()
            {
                Address = request.Address,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserId = _userId
            };

            var result = await _personalDataService.CreateAsync(entity);

            return this.Ok(result);
        }
    }
}
