using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SplitPurchases.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Persistence.EntityTypeConfiguration
{
    public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.ToTable("UserGroups");
            builder.HasKey(ug => new {ug.UserId, ug.GroupId});
            builder.Property(p => p.Balance).HasColumnType("decimal(18,2)").IsRequired();
            builder.HasOne(ug => ug.User).WithMany(u => u.UserGroups).HasForeignKey(ug => ug.UserId);
            builder.HasOne(ug => ug.Group).WithMany(g => g.UserGroups).HasForeignKey(ug => ug.GroupId);
        }
    }
}
