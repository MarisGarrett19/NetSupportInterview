#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using Application;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DemoData;

/// <summary>
///     This resets the data in the database, you should not need to make any changes here.
/// </summary>
public sealed class DemoDataService : IDemoDataService
{
    private static User _user1;
    private static User _user2;
    private static User _user3;
    private static Group _group1;
    private static Group _group2;
    private static Group _group3;

    private readonly IAppDbContext _appDbContext;

    public DemoDataService(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;

        CreateDemoUsers();
        CreateDemoGroups();
    }

    public async Task ResetDatabaseData(CancellationToken cancellationToken)
    {
        await _appDbContext.GroupMembers.ExecuteDeleteAsync(cancellationToken);

        await _appDbContext.Groups.ExecuteDeleteAsync(cancellationToken);

        await _appDbContext.Users.ExecuteDeleteAsync(cancellationToken);

        await _appDbContext.SaveChangesAsync(cancellationToken);

        _appDbContext.Users.Add(_user1);
        _appDbContext.Users.Add(_user2);
        _appDbContext.Users.Add(_user3);

        _appDbContext.Groups.Add(_group1);
        _appDbContext.Groups.Add(_group2);
        _appDbContext.Groups.Add(_group3);

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public static void CreateDemoGroups()
    {
        _group1 = Group.Create(Guid.NewGuid(), "Demo Group 1");

        _group1.Members = new List<GroupMember>
        {
            GroupMember.Create(Guid.NewGuid(), _group1.Id, _user1.Id, DateTime.UtcNow.AddDays(-40), DateTime.MaxValue),
            GroupMember.Create(Guid.NewGuid(), _group1.Id, _user2.Id, DateTime.UtcNow.AddDays(-20), DateTime.MaxValue),
            GroupMember.Create(Guid.NewGuid(), _group1.Id, _user3.Id, DateTime.UtcNow.AddDays(-12), DateTime.MaxValue),
        };

        _group2 = Group.Create(Guid.NewGuid(), "Demo Group 2");

        _group2.Members = new List<GroupMember>
        {
            GroupMember.Create(Guid.NewGuid(), _group2.Id, _user1.Id, DateTime.UtcNow.AddDays(-40), DateTime.MaxValue)
        };

        _group3 = Group.Create(Guid.NewGuid(), "Demo Group 3");
    }

    public static void CreateDemoUsers()
    {
        _user1 = User.Create(Guid.NewGuid(), "demo-user-1@netsupportsoftware.com");
        _user2 = User.Create(Guid.NewGuid(), "demo-user-1@netsupportsoftware.com");
        _user3 = User.Create(Guid.NewGuid(), "demo-user-1@netsupportsoftware.com");
    }
}

public interface IDemoDataService
{
    /// <summary>
    ///     Call this method to reset the demo databases data.
    /// </summary>
    /// <returns></returns>
    Task ResetDatabaseData(CancellationToken cancellationToken);
}
