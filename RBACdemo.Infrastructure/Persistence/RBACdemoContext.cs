﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RBACdemo.Infrastructure.Core.Domain;

namespace RBACdemo.Infrastructure.Persistence
{
    public class RBACdemoContext : IdentityDbContext<ApplicationUser>
    {
      
        public DbSet<MenuItem> MenuItems { get; set; }
     
        public RBACdemoContext(DbContextOptions<RBACdemoContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=demotest.db");
            base.OnConfiguring(optionsBuilder);
        }
    }

}