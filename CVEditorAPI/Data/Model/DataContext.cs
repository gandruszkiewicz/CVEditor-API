using System;
using System.Collections.Generic;
using System.Text;
using CVEditorAPI.Data.Model.ResumeCompoments;
using CVEditorAPI.Data.Model.ResumeComponents;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CVEditorAPI.Data.Model
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Resume> Resumes { get; set; }

        public DbSet<ProfessionalExperience> ProfessionalExperiences { get; set; }

        public DbSet<Qualification> Qualifications { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
