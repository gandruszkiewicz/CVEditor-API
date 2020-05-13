using AutoMapper;
using CVEditorAPI.Data.Dtos.Requests.ResumeComponents;
using CVEditorAPI.Data.Model.ResumeCompoments;
using CVEditorAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Controllers.V1
{
    public class SkillController: Controller
    {
        private readonly IMapper _mapper;

        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService, IMapper mapper)
        {
            this._mapper = mapper;
            this._skillService = skillService;
        }

        [HttpGet(Concracts.V1.ApiRoutes.Skill.GetAll)]
        public IActionResult GetAll(int resumeId)
        {
            var personalDatas =
                this._skillService.GetAll(resumeId);

            return Ok(personalDatas);
        }

        [HttpPost(Concracts.V1.ApiRoutes.Skill.Post)]
        public async Task<IActionResult> Post([FromBody] SkillPostRequest request)
        {
            var entity = _mapper.Map<Skill>(request);

            var result = await _skillService.CreateAsync(entity);

            return this.Ok(result);
        }
    }
}
