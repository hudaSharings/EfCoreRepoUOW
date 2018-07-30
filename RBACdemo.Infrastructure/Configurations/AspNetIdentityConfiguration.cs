using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RBACdemo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Configurations
{
  public  class AspNetIdentityConfiguration
    {
        public static void ConfigureService(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                           .AddEntityFrameworkStores<RBACdemoContext>()
                           .AddDefaultTokenProviders();
        }
    }
}
