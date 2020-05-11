using CVEditorAPI.Data.Model;
using CVEditorAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Services
{
    public class ProfessionalExperienceService: 
        Service<ProfessionalExperience>, IProfessionalExperienceService
    {
        public ProfessionalExperienceService(DataContext context)
            :base(context)
        {

        }
    }
}
