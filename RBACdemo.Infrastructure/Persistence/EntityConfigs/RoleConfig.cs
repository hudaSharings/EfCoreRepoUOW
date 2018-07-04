using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBACdemo.Infrastructure.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Persistence.EntityConfigs
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }

}
