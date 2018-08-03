using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RBACdemo.Infrastructure.Repositories;
using RBACdemo.Core.Repositories;
using RBACdemo.Infrastructure;
using RBACdemo.Filters;
using FluentValidation.AspNetCore;
using RBACdemo.Dto;
using Serilog;
using System.IO;
using NSwag.AspNetCore;
using System.Reflection;
using NJsonSchema;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

namespace RBACdemo
{
    public class Startup
    {
        RBACdemoServiceFactory rbacDemoConfig;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            rbacDemoConfig = new RBACdemoServiceFactory(Configuration);
            Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.RollingFile(Path.Combine(env.ContentRootPath, "logs\\log-{Date}.txt"))
        .CreateLogger();
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            rbacDemoConfig.config(services);
            //services.AddScoped<ValidateModelAttribute>();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelAttribute));
                options.Filters.Add(typeof(ApiExceptionFilter));
               
            })
        .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterDtoValidation>());

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins(Configuration.GetSection("CorsValues")["AllowedOrigins"]));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("AllowSpecificOrigin");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                    PropertyNameHandling.CamelCase;
            });

        }
    }
}
