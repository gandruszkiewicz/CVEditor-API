using CVEditorAPI.Concracts.V1;
using CVEditorAPI.Data.Dtos;
using CVEditorAPI.Data.Dtos.Responses;
using CVEditorAPI.Services;
using CVEditorAPI.Services.Interfaces;
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
        public async Task<IActionResult> Register([FromBody] UserIdentityDto request)
        {
            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            if (!authResponse.IsSuccess)
            {
                return this.BadRequest(new IdentityFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return this.Ok(new IdentitySuccessResponse 
            {
                Token = authResponse.Token
            });

        }

        [HttpPost(template: ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] UserIdentityDto request)
        {

            var authResponse = await _identityService.LoginAsync(request.Email, request.Password);

            if (!authResponse.IsSuccess)
            {
                return this.BadRequest(new IdentityFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return this.Ok(new IdentitySuccessResponse
            {
                UserName = authResponse.UserName,
                Token = authResponse.Token,
                UserId = authResponse.UserId
            });

        }

        [HttpGet(template: ApiRoutes.Identity.CheckIfUserExist)]
        public IActionResult CheckIfUserExist(string userId)
        {

            var authResponse = _identityService.GetFirstOrDefault(x => x.Id == userId);
            var result = authResponse != null;
            return this.Ok(result);

        }
    }
}
