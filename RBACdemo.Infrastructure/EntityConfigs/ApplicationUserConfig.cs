using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBACdemo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.EntityConfigs
{
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .HasOne(t => t.Tenant)
                .WithMany(u => u.Users)
                .HasForeignKey(t => t.TenantNo)
                .HasPrincipalKey(u => u.TenantNo);

            builder.HasOne(r => r.Role)
                .WithMany(us => us.Users)
                .HasForeignKey(r => r.RoleId)
                .HasPrincipalKey(us => us.Id);
                

        }
    }
}
