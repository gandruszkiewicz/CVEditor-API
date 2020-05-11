using CVEditorAPI.Data.Dtos.Responses;
using CVEditorAPI.Data.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Services.Interfaces
{
    public interface IIdentityService: IService<User>
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);

        Task<AuthenticationResult> LoginAsync(string email, string password);
    }
}
