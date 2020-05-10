using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Concracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class PersonalData
        {
            public const string GetAll = Base + "/personalDatas";

            public const string Post = Base + "personalDatas";
        }

        public static class Identity
        {
            public const string Login = Base + "identity/login";

            public const string Register = Base + "identity/register";
        }
    }
}
