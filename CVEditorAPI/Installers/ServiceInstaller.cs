using CVEditorAPI.Services;
using CVEditorAPI.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IResumeService, ResumeService>();

            services.AddSingleton<IExperience, 
                ExperienceService>();

            services.AddSingleton<IQualificationService,
                    QualificationService>();

            services.AddScoped<IIdentityService, IdentityService>();

            services.AddScoped<ISkillService, SkillService>();
        }
    }
}
