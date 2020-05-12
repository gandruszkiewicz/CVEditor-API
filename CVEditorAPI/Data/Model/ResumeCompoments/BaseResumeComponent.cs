using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Data.Model.ResumeComponents
{
   public abstract class BaseResumeComponent
   {
        [ForeignKey("Resume")]
        public int ResumeId { get; set; }

        public Resume Resume { get; set; }
   }
}
