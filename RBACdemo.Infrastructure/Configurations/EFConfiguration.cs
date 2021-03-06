﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RBACdemo.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Configurations
{
  public  class EFConfiguration
    {
        public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<RBACdemoContext>(
              options => options.UseSqlServer(configuration.GetConnectionString("IdentityDemoConnection"))
               );
           
        }
    }
}
