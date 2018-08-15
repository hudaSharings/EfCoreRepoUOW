using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBACdemo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.EntityConfigs
{
    public class RoleMenuItemConfig : IEntityTypeConfiguration<RoleMenuItem>
    {
        public void Configure(EntityTypeBuilder<RoleMenuItem> builder)
        {
            builder.HasOne(u => u.Role)
               .WithMany(um => um.RoleMenuItems)
               .HasForeignKey(u => u.RoleId);

            builder.HasOne(m => m.MenuItem)
                .WithMany(um => um.RoleMenuItems)
                .HasForeignKey(m => m.MenuItemNo)
                .HasPrincipalKey(um => um.MenuItemNo);
        }
    }
}
