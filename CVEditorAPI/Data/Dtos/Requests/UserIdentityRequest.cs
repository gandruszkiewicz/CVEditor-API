using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Data.Dtos.Requests
{
    public class UserIdentityRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
