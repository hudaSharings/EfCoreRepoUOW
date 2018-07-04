using Microsoft.EntityFrameworkCore;
using RBACdemo.Infrastructure.Persistence.EntityConfigs;
using RBACdemo.Infrastructure.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.EfCore
{
    
    public class RBACdemoContext : DbContext
    {
        public DbSet<user> Users { get; set; }
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
            optionsBuilder.UseSqlite("demotestdb");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new PermissionConfig());
            modelBuilder.ApplyConfiguration(new RolePermissionConfig());
            modelBuilder.ApplyConfiguration(new MenuItemConfig());
            modelBuilder.ApplyConfiguration(new UserMenuItemConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
