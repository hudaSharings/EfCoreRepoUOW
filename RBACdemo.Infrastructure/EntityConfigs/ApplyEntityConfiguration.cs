using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.EntityConfigs
{
    public static class ApplyEntityConfiguration
    {
        public static void ApplyConfigurationsForEntities(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MenuItemConfig());
            builder.ApplyConfiguration(new TenantConfig());
            builder.ApplyConfiguration(new RoleMenuItemConfig());
            builder.ApplyConfiguration(new ApplicationUserConfig());
        }

        public static void HasSequences(this ModelBuilder builder)
        {
            builder.HasSequence<int>("OrderNumbers", schema: "shared")
                .StartsAt(1).IncrementsBy(1);
            builder.HasSequence<int>("TenantNumbers", schema: "shared")
                .StartsAt(1).IncrementsBy(1);
        }
    }
}
