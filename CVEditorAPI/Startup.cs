﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CVEditorAPI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CVEditorAPI.Configurations;
using Swashbuckle.AspNetCore.Swagger;
using CVEditorAPI.Installers;
using Microsoft.Extensions.Hosting;
using CVEditorAPI.Data.Model;

namespace CVEditorAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServicesAssembly(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseDeveloperExceptionPage();

            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
            //    context.Database.EnsureCreated();
            //}

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseAuthentication();

            var swaggerOptions = new Configurations.SwaggerOptions();
            Configuration.GetSection(nameof(Configurations.SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(options => options.RouteTemplate = swaggerOptions.JsonRoute);
            app.UseSwaggerUI(options => 
                options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description));

            app.UseCors(
                options => options.SetIsOriginAllowed(x => _ = true).WithOrigins("http://localhost:3000/").AllowAnyMethod().AllowAnyHeader().AllowCredentials()
            );

            app.UseMvc();
        }
    }
}
