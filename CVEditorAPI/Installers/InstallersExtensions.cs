using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVEditorAPI.Installers
{
    public static class InstallersExtensions
    {
        public static void InstallServicesAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>().ToList();

            installers.ForEach(x =>
            {
                x.InstallServices(services, configuration);
            });
        }
    }
}
