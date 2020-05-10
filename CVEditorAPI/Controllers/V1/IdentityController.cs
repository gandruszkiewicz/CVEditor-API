using CVEditorAPI.Concracts.V1;
using CVEditorAPI.Data.Dtos;
using CVEditorAPI.Data.Dtos.Requests;
using CVEditorAPI.Data.Dtos.Responses;
using CVEditorAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Controllers.V1
{
    public class IdentityController: Controller
    {

        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            this._identityService = identityService;
        }

        [HttpPost(template: ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {

            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            if (!authResponse.IsSuccess)
            {
                return this.BadRequest(new RegistrationFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return this.Ok(new RegistrationSuccessResponse 
            {
                Token = authResponse.Token
            });

        }
    }
}
