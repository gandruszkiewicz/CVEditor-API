using CVEditorAPI.Data;
using CVEditorAPI.Data.Model.ResumeCompoments;
using CVEditorAPI.Data.Model.ResumeComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Data.Model
{
    public class Resume
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string SumUp { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Experience> ProfessionalExperiences { get; set; }

        public ICollection<Qualification> Qualifications { get; set; }

        public ICollection<Skill> Skills { get; set; }
    }
}
