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
using RBACdemo.Infrastructure.Persistence.Repositories;
using RBACdemo.Infrastructure.Core.Repositories;
using RBACdemo.Infrastructure.Persistence;
using RBACdemo.Infrastructure;

namespace RBACdemo
{
    public class Startup
    {
        RBACdemoServiceFactory rbacDemoConfig;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            rbacDemoConfig = new RBACdemoServiceFactory(Configuration);
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            rbacDemoConfig.config(services);        
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
