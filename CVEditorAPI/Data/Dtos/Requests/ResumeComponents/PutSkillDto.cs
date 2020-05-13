using CVEditorAPI.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Data.Dtos.Requests.ResumeComponents
{
    public class PutSkillDto: BaseRequestResumeComponentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public SkillLevelEnum SkillLevel { get; set; }
    }
}
