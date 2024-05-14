using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SplitPurchases.Domain.Entities;



namespace SplitPurchases.Persistence.EntityTypeConfiguration
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchases");
            builder.HasKey(p => p.PurchaseId);
            builder.Property(p => p.Amount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(100);
            builder.Property(p => p.PurchaseDate).HasColumnName("datetime");
            builder.Property(p => p.PurchaseStatus).IsRequired();

            builder.HasOne(p => p.Group).WithMany(g => g.Purchases).HasForeignKey(p => p.GroupId);
            builder.HasOne(p => p.User).WithMany(n => n.Purchases).HasForeignKey(p => p.UserId);

        }
    }
}
