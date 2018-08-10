using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBACdemo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.EntityConfigs
{
   public class TenantConfig : IEntityTypeConfiguration<Tenant>
    {

        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TenantNo)
                .HasDefaultValueSql("NEXT VALUE FOR shared.TenantNumbers");
        }
    }
}
