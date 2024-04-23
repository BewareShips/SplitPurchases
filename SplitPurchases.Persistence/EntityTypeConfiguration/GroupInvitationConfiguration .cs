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
    public class GroupInvitationConfiguration : IEntityTypeConfiguration<GroupInvitation>
    {
        public void Configure(EntityTypeBuilder<GroupInvitation> builder)
        {
            builder.ToTable("GroupInvitations");
            builder.HasKey(gi => gi.Id);

            builder.Property(gi => gi.GroupId).IsRequired();
            builder.Property(gi => gi.InvitedUserId);
            builder.Property(gi => gi.InvitedByUserId);
            builder.Property(gi => gi.InvitateStatus).IsRequired();
            builder.Property(gi => gi.SendDate).IsRequired();
            builder.Property(gi => gi.ExpirationDate).IsRequired();


            builder.HasOne(gi => gi.Group).WithMany().HasForeignKey(g => g.GroupId).OnDelete(DeleteBehavior.Cascade); //after deliting group we delete all ivitations
            builder.HasOne(gi => gi.InvitedUser).WithMany().HasForeignKey(g => g.InvitedUserId).OnDelete(DeleteBehavior.SetNull); //Setting InvitedUserId to null after deleting User
            builder.HasOne(gi => gi.InvitedByUser).WithMany().HasForeignKey(g => g.InvitedByUserId).OnDelete(DeleteBehavior.SetNull);//Setting InvitedByUserId to null after deleting User
        }
    }
}
