using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RBACdemo.Core;
using RBACdemo.Core.Domain;
using RBACdemo.Core.Persistence;
using RBACdemo.Core.Repositories;
using RBACdemo.Core.Services;
using RBACdemo.Core.Settings;
using RBACdemo.Infrastructure;
using RBACdemo.Infrastructure.Configurations;
using RBACdemo.Infrastructure.Persistence;
using RBACdemo.Infrastructure.Repositories;
using RBACdemo.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure
{
    public class RBACdemoServiceFactory
    {
        public IConfiguration Configuration { get; }
        public RBACdemoServiceFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       
        public void config(IServiceCollection services)
        {
            JwtSetting.Audience = Configuration.GetSection("JwtTokenValues")["audience"].ToString();
            JwtSetting.Issuer = Configuration.GetSection("JwtTokenValues")["issuer"].ToString();
            JwtSetting.SecreteKey = Configuration.GetSection("JwtTokenValues")["securityKey"].ToString();
            JwtSetting.ExpairesInMinutes=Convert.ToInt32(Configuration.GetSection("JwtTokenValues")["expairesInMinutes"]);

            EFConfiguration.ConfigureService(services, Configuration);
            AspNetIdentityConfiguration.ConfigureService(services, Configuration);
            AuthenticationConfiguration.ConfigureService(services, Configuration);
            IocConfigurationRepository.ConfigureService(services, Configuration);
            IocConfigurationService.ConfigureService(services, Configuration);

            services.AddTransient<IDataBaseManager, DataBaseManager>();
            services.AddScoped(
             x => new ConnectionSetting(Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddScoped<SpHelper>();
        }

    }
}
