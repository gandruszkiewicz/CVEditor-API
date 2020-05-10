using CVEditorAPI.Configurations;
using CVEditorAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEditorAPI.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(key: nameof(JwtSettings), jwtSettings);

            services.AddSingleton(jwtSettings);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAuthentication(configureOptions: conf =>
            {
                conf.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                conf.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                conf.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(conf =>
            {
                conf.SaveToken = true;
                conf.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key: Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });


            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "CVEditor API", Version = "v1" });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[0]}
                };

                x.AddSecurityDefinition(name: "Bearer", new ApiKeyScheme
                {
                    Description = "JWT Auth header using bearer scheme",
                    Name = "Authorization",
                    In = "Header",
                    Type = "apikey"
                });
                x.AddSecurityRequirement(security);
            });
        }
    }
}
