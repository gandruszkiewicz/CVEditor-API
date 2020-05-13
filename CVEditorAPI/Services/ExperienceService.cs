using CVEditorAPI.Data.Model;
using CVEditorAPI.Data.Model.ResumeComponents;
using CVEditorAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Services
{
    public class ExperienceService: 
        Service<Experience>, IExperience
    {
        public ExperienceService(DataContext context)
            : base(context)
        {

        }
    }
}
