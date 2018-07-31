using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RBACdemo.Core;
using RBACdemo.Core.Domain;
using RBACdemo.Core.Repositories;
using RBACdemo.Core.Services;
using RBACdemo.Core.Settings;
using RBACdemo.Infrastructure;
using RBACdemo.Infrastructure.Configurations;
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
            JwtValues.Audience = Configuration.GetSection("JwtTokenValues")["audience"].ToString();
            JwtValues.Issuer = Configuration.GetSection("JwtTokenValues")["issuer"].ToString();
            JwtValues.SecreteKey = Configuration.GetSection("JwtTokenValues")["securityKey"].ToString();
            JwtValues.ExpairesInMinutes=Convert.ToInt32(Configuration.GetSection("JwtTokenValues")["expairesInMinutes"]);

            
            EFConfiguration.ConfigureService(services, Configuration);
            AspNetIdentityConfiguration.ConfigureService(services, Configuration);
            AuthenticationConfiguration.ConfigureService(services, Configuration);
            IocConfiguration.ConfigureService(services, Configuration);
           
        }

    }
}
