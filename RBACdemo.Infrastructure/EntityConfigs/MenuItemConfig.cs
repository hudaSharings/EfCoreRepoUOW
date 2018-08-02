using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBACdemo.Core.Domain;

namespace RBACdemo.Infrastructure.EntityConfigs
{
    public class MenuItemConfig : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(x => x.Id);     
            builder.Property(x=>x.MenuItemNo)
                .HasDefaultValueSql("NEXT VALUE FOR shared.OrderNumbers");
        }
        
    }

}
