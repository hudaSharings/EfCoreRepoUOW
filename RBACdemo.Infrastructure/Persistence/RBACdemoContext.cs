using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RBACdemo.Core.Domain;
using RBACdemo.Infrastructure.EntityConfigs;

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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MenuItemConfig());
            builder.ApplyConfiguration(new TenantConfig());
            builder.HasSequence<int>("OrderNumbers", schema: "shared")
                .StartsAt(1).IncrementsBy(1);
            builder.HasSequence<int>("TenantNumbers", schema: "shared")
                .StartsAt(1).IncrementsBy(1);

            base.OnModelCreating(builder);
        }
    }

}
