using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RBACdemo.Core.Domain;
using RBACdemo.Infrastructure.EntityConfigs;

namespace RBACdemo.Infrastructure
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
            builder.HasSequence<int>("OrderNumbers", schema: "shared")
                .StartsAt(100).IncrementsBy(1);

           
            base.OnModelCreating(builder);
        }
    }

}
