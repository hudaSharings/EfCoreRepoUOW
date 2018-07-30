using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBACdemo.Core.Domain;

namespace RBACdemo.Infrastructure.Persistence.EntityConfigs
{
    public class UserMenuItemConfig : IEntityTypeConfiguration<UserMenuItem>
    {
        public void Configure(EntityTypeBuilder<UserMenuItem> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }

}
