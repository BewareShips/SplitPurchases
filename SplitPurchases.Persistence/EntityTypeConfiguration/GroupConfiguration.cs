using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SplitPurchases.Domain.Entities;


namespace SplitPurchases.Persistence.EntityTypeConfiguration
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");
            builder.HasKey(g => g.GroupId);
            builder.Property(g => g.GroupName).IsRequired().HasMaxLength(200);

            builder.HasMany(g =>g.UserGroups).WithOne(ug => ug.Group).HasForeignKey(g => g.GroupId);
            builder.HasMany(g => g.Purchases).WithOne(p => p.Group).HasForeignKey(g => g.GroupId);
        }
    }
}


