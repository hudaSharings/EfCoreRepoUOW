using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RBACdemo.Infrastructure.Core;
using RBACdemo.Infrastructure.Core.Repositories;
using RBACdemo.Infrastructure.Persistence;
using RBACdemo.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure
{
    public class RBACdemoServiceFactory
    {
        public IConfiguration Config { get; }
        public RBACdemoServiceFactory(IConfiguration configuration)
        {
            Config = configuration;
        }

        public void config(IServiceCollection services)
        {
            services.AddScoped<RBACdemoContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

    }
}
