using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RBACdemo.Infrastructure.Core;
using RBACdemo.Infrastructure.Core.Domain;
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
        public IConfiguration Configuration { get; }
        public RBACdemoServiceFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void config(IServiceCollection services)
        {
            //services.AddScoped<RBACdemoContext>();
            services.AddDbContext<RBACdemoContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("IdentityDemoConnection"))
                );
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<RBACdemoContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "https://localhost:44335",
                    ValidIssuer = "https://localhost:44335",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"))

                };
            });


            services.AddTransient<UserManager<ApplicationUser>>();
            services.AddTransient<SignInManager<ApplicationUser>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
        }

    }
}
