using Microsoft.EntityFrameworkCore;
using SplitPurchases.Domain.Entities;


namespace SplitPurchases.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Group> Groups { get; set; }
        DbSet<Purchase> Purchases { get; set;}
        DbSet<User> Users { get; set; }
        DbSet<UserGroup> UserGroups { get; set; }
        DbSet<GroupInvitation>GroupInvitations { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
