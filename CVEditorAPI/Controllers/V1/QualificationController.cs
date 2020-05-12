using AutoMapper;
using CVEditorAPI.Data.Dtos.Requests.ResumeComponents;
using CVEditorAPI.Data.Model.ResumeComponents;
using CVEditorAPI.Services;
using CVEditorAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Controllers.V1
{
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
        public IActionResult GetAll()
        {
            var personalDatas =
                this._qualificationService.GetAll();

            return Ok(personalDatas);
        }

        [HttpPost(Concracts.V1.ApiRoutes.Qualification.Post)]
        public async Task<IActionResult> Post([FromBody] QualificationPostRequest request)
        {
            var entity = _mapper.Map<Qualification>(request);

            var result = await _qualificationService.CreateAsync(entity);

            return this.Ok(result);
        }

    }
}
