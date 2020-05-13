using CVEditorAPI.Data.Enums;
using CVEditorAPI.Data.Model.ResumeComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Data.Model.ResumeCompoments
{
    public class Skill: BaseResumeComponent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public SkillLevelEnum SkillLevel { get; set; }
    }
}
