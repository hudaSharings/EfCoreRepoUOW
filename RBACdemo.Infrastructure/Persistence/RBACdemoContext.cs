using Microsoft.EntityFrameworkCore;
using RBACdemo.Infrastructure.Core.Domain;

namespace RBACdemo.Infrastructure.Persistence
{
    public class RBACdemoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<UserMenuItem> UserMenuItems { get; set; }
        public RBACdemoContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=demotest.db");
            base.OnConfiguring(optionsBuilder);
        }
    }

}
