using CVEditorAPI.Data.Model.ResumeComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Data.Model.ResumeComponents
{
    public class Experience: BaseResumeComponent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string City { get; set; }

        public string Position { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public string Description { get; set; }
    }
}
