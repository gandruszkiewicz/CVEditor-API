﻿using AutoMapper;
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

        private readonly IResumeService _resume;
        private readonly IMapper _mapper;

        public ResumeController(IResumeService resume, IMapper mapper)
        {
            this._resume = resume;
            this._mapper = mapper;
        }

        [HttpGet(Concracts.V1.ApiRoutes.Resumes.GetAll)]
        public IActionResult GetAll()
        {
            var resumes =
                this._resume.GetAll(this.User.GetUserId()).ToList();

            return Ok(resumes);
        }

        [HttpPost(Concracts.V1.ApiRoutes.Resumes.Post)]
        public async Task<IActionResult> Post([FromBody] ResumeDto resumeDto)
        {
            var entity = _mapper.Map<Resume>(resumeDto);

            entity.UserId = this.User.GetUserId();

            var result = await _resume.CreateAsync(entity);

            return this.Ok(result);
        }
    }
}
