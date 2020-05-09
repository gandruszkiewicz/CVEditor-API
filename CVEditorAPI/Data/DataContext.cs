using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CVEditorAPI.Data
{
    public class DataContext : IdentityDbContext, IDataContext
    {
        public DbSet<PersonalData> PersonalDatas { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
