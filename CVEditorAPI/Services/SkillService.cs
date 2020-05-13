using CVEditorAPI.Data.Model;
using CVEditorAPI.Data.Model.ResumeCompoments;
using CVEditorAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Services
{
    public class SkillService: Service<Skill>, ISkillService
    {
        public SkillService(DataContext context)
            :base(context)
        {

        }
    }
}
