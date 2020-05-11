using CVEditorAPI.Data;
using CVEditorAPI.Data.Dtos;
using CVEditorAPI.Data.Dtos.Requests;
using CVEditorAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonalDataController: Controller
    {

        private readonly IPersonalDataService _personalDataService;

        public PersonalDataController(IPersonalDataService personalDataService)
        {
            _personalDataService = personalDataService;
        }

        [HttpGet(Concracts.V1.ApiRoutes.PersonalData.GetAll)]
        public IActionResult GetAll()
        {
            var personalDatas = 
                this._personalDataService.GetAll();

            return Ok(personalDatas);
        }

        [HttpPost(Concracts.V1.ApiRoutes.PersonalData.Post)]
        public async Task<IActionResult> Post([FromBody] PersonalDataPostRequest request)
        {
            var entity = new PersonalData()
            {
                Address = request.Address,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var result = _personalDataService.CreateAsync(entity);

            return this.Ok(result);
        }
    }
}
