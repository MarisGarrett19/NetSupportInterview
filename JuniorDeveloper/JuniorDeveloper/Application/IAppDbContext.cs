using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application;

public interface IAppDbContext
{
    DbSet<Group> Groups { get; }

    DbSet<GroupMember> GroupMembers { get; }

    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    int SaveChanges();
}
