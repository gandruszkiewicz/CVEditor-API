using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Data.Dtos.Responses
{
    public class IdentityFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
