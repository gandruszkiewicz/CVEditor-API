﻿using CVEditorAPI.Data;
using CVEditorAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Controllers.V1
{
    public class PersonalDataController: Controller
    {
        private List<PersonalData> _personalDatas;

        private readonly IPersonalDataService _personalDataService;

        public PersonalDataController(IPersonalDataService personalDataService)
        {
            _personalDataService = personalDataService;

            _personalDatas = new List<PersonalData>();
            for(var index = 0; index < 5; index++)
            {
                _personalDatas.Add(new PersonalData
                {
                    FirstName = $"Grzegorz {index}",
                    LastName = "Andre",
                    Address = "Fajna 34, Janowo, 34-555, Poland",
                    Email = "dupa@gmail.com",
                    Id = index
                });
            }
        }

        [HttpGet(Concracts.V1.ApiRoutes.PersonalData.GetAll)]
        public IActionResult GetAll()
        {
            var personalDatas = this._personalDataService.GetAll().Concat(_personalDatas);
            return Ok(personalDatas);
        }
    }
}
