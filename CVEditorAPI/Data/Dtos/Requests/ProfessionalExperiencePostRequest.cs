﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Data.Dtos.Requests
{
    public class ProfessionalExperiencePostRequest
    {
        public string CompanyName { get; set; }

        public string City { get; set; }

        public string Position { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public string Description { get; set; }

        public int ResumeId { get; set; }
    }
}
