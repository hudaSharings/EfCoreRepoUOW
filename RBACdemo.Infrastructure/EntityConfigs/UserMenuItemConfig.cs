using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBACdemo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.EntityConfigs
{
    public class UserMenuItemConfig : IEntityTypeConfiguration<UserMenuItem>
    {
        public void Configure(EntityTypeBuilder<UserMenuItem> builder)
        {
            builder.HasOne(u => u.User)
               .WithMany(um => um.UserMenuItems)
               .HasForeignKey(u => u.UserId);

            builder.HasOne(m => m.MenuItem)
                .WithMany(um => um.UserMenuItems)
                .HasForeignKey(m => m.MenuItemNo);
        }
    }
}
