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

        public const string GetAll = Base;

        public static class Resumes
        {

            public const string GetAll = BaseEndpoint;

            public const string Get = BaseEndpoint + "/{resumeId}";

            public const string Post = BaseEndpoint;

            public const string Put = BaseEndpoint;

            public const string Delete = BaseEndpoint;

            private const string BaseEndpoint = Base + "/resume";
        }

        public static class Experience
        {
            public const string GetAll = BaseEndpoint + "/{resumeId}";

            public const string Get = BaseEndpoint + "/{experienceId}";

            public const string Post = BaseEndpoint;

            public const string Put = BaseEndpoint;

            public const string Delete = BaseEndpoint;

            private const string BaseEndpoint = Base + "/experience";
        }

        public static class Qualification
        {
            public const string GetAll = BaseEndpoint + "/{resumeId}";

            public const string Get = BaseEndpoint + "/{qualificationId}";

            public const string Post = BaseEndpoint;

            public const string Put = BaseEndpoint;

            public const string Delete = BaseEndpoint;

            private const string BaseEndpoint = Base + "/qualification";
        }

        public static class Skill
        {
            public const string GetAll = BaseEndpoint + "/{resumeId}";

            public const string Get = BaseEndpoint + "/{skillId}";

            public const string Post = BaseEndpoint;

            public const string Put = BaseEndpoint;

            public const string Delete = BaseEndpoint;

            private const string BaseEndpoint = Base + "/skill";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";
        }
    }
}
