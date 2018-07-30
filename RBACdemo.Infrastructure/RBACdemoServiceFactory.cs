using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RBACdemo.Core;
using RBACdemo.Core.Domain;
using RBACdemo.Core.Repositories;
using RBACdemo.Core.Services;
using RBACdemo.Infrastructure;
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
                    ValidAudience =JwtValues.Audience, //"https://localhost:44335",
                    ValidIssuer =JwtValues.Issuer ,//"https://localhost:44335",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtValues.SecreteKey))

                };
            });


            services.AddTransient<UserManager<ApplicationUser>>();
            services.AddTransient<SignInManager<ApplicationUser>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            //--
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

    }
}
