using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Users;

public class UserService : IUserService
{
    private readonly IAppDbContext _appDbContext;

    public UserService(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    /// <inheritdoc />
    public async Task Add(User user, CancellationToken cancellationToken)
    {
        //added a check to see if the user email is already in use.
        if (await _appDbContext.Users.Where(m => m.Email == user.Email).AnyAsync())
        {
            throw new ArgumentException("Can't add a user that already exists.");
        }

        _appDbContext.Users.Add(user);

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task Delete(Guid userId, CancellationToken cancellationToken)
    {
        _appDbContext.Users.Remove(await GetById(userId, cancellationToken));

        await _appDbContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task<List<User>> GetAll(CancellationToken cancellationToken)
    {
        return await _appDbContext.Users
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<User> GetById(Guid userId, CancellationToken cancellationToken)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("Id must not be empty.", nameof(userId));
        }

        return await _appDbContext.Users
            .FirstAsync(m => m.Id == userId);
    }

    /// <inheritdoc />
    public async Task Update(UpdateUserOptions options, CancellationToken cancellationToken)
    {
        var user = await GetById(options.UserId, cancellationToken);

        if (await _appDbContext.Users.Where(m => m.Email == options.Email && m.Id != options.UserId).AnyAsync())
        {
            throw new ArgumentException("Can't add a user that already exists.");
        }

        user.Email = options.Email;

        await _appDbContext.SaveChangesAsync();
    }
}

public interface IUserService
{
    /// <summary>
    ///     Add the provided user to the database.
    ///     Users should not be able to be added if they have the same email as another user.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task Add(User user, CancellationToken cancellationToken);

    /// <summary>
    ///     Delete the specified user.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task Delete(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    ///     Get all of the users.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<User>> GetAll(CancellationToken cancellationToken);

    /// <summary>
    ///     Get the user with the specified id.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<User> GetById(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    ///     Update the users details.
    ///     User emails should not be able to be updated if the target email is already in use by another user.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task Update(UpdateUserOptions options, CancellationToken cancellationToken);
}

public sealed class UpdateUserOptions
{
    public required Guid UserId { get; init; }

    public required string Email { get; init; }
}