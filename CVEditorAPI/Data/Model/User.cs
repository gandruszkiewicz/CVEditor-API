using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Data.Model
{
    public class User: IdentityUser
    {
        public User()
        {
            this.Resumes = new Collection<Resume>();
        }

        public ICollection<Resume> Resumes { get; set; }
    }
}
