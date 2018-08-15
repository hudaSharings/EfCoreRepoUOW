using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RBACdemo.Core.Domain;
using RBACdemo.Infrastructure.EntityConfigs;


namespace RBACdemo.Infrastructure.Persistence
{
    public class RBACdemoContext : IdentityDbContext<ApplicationUser>
    {
      
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<RoleMenuItem> RoleMenuItems { get; set; }


        public RBACdemoContext(DbContextOptions<RBACdemoContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsForEntities();
            builder.HasSequences();
            


            base.OnModelCreating(builder);
        }
    }

}
