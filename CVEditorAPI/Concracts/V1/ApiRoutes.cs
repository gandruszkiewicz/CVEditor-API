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

        public static class Resumes
        {
            public const string GetAll = Base + "/resumes";

            public const string Post = Base + "/resumes";
        }

        public static class ProfessionalExperience
        {
            public const string GetAll = Base + "/professonalExperience";

            public const string Post = Base + "/professonalExperience";
        }

        public static class Qualification
        {
            public const string GetAll = Base + "/qualification";

            public const string Post = Base + "/qualification";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";
        }
    }
}
