using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RBACdemo.Core;
using RBACdemo.Core.Domain;
using RBACdemo.Core.Persistence;
using RBACdemo.Core.Repositories;
using RBACdemo.Core.Services;
using RBACdemo.Core.Settings;
using RBACdemo.Infrastructure.Persistence;
using RBACdemo.Infrastructure.Repositories;
using RBACdemo.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Configurations
{
  public static  class IocConfigurationRepository
    {
        public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IContextFactory, RBACdemoContextFactory>();
            services.AddTransient<UserManager<ApplicationUser>>();
            services.AddTransient<SignInManager<ApplicationUser>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IMenuItemRepository, MenuItemRepository>();
            services.AddTransient<ITenantRepository, TenantRepository>();
            
        }
    }
}
