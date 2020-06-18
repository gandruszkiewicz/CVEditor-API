﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Data.Dtos.Requests.ResumeComponents
{
    public class PutResumeDto
    {
        public int Id { get; set; }

        public string DocumentName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string SumUp { get; set; }
    }
}
