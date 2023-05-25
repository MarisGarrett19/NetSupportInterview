using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Groups;

public class GroupService : IGroupService
{
    private readonly IAppDbContext _appDbContext;

    public GroupService(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    /// <inheritdoc />
    public async Task Add(Group group, CancellationToken cancellationToken)
    {
        _appDbContext.Groups.Add(group);

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public void Delete(Guid id)
    {
        _appDbContext.Groups.Remove(GetById(id));

        _appDbContext.SaveChanges();
    }

    /// <inheritdoc />
    public List<Group> GetAll()
    {
        return _appDbContext.Groups
            .Include(m => m.Members)
            .ToList();
    }

    /// <inheritdoc />
    public Group GetById(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id must not be empty.", nameof(id));
        }

        return _appDbContext.Groups
            .Include(m => m.Members)
            .First();
    }

    /// <inheritdoc />
    public void Update(UpdateGroupOptions options)
    {
        var group = GetById(options.GroupId);

        group.Name = options.Name;

        _appDbContext.SaveChanges();
    }
}

public interface IGroupService
{
    /// <summary>
    ///     Add the provided group to the database.
    ///     Groups should not be able to be added if they have the same name as another group.
    /// </summary>
    /// <param name="group"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task Add(Group group, CancellationToken cancellationToken);

    /// <summary>
    ///     Delete the specified group.
    /// </summary>
    /// <param name="id"></param>
    void Delete(Guid id);

    /// <summary>
    ///     Get all of the groups.
    /// </summary>
    /// <returns></returns>
    List<Group> GetAll();

    /// <summary>
    ///     Get the group with the specified id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Group GetById(Guid id);

    /// <summary>
    ///     Update the groups details.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    void Update(UpdateGroupOptions options);
}

public sealed class UpdateGroupOptions
{
    public required Guid GroupId { get; init; }

    public required string Name { get; init; }
}
