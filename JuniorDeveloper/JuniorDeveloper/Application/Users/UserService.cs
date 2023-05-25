using Domain;

namespace Application.Users;

public class UserService : IUserService
{
    /// <inheritdoc />
    public Task Add(User user, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    /// <inheritdoc />
    public Task Delete(Guid userId, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    /// <inheritdoc />
    public Task<List<User>> GetAll(CancellationToken cancellationToken)
        => throw new NotImplementedException();

    /// <inheritdoc />
    public Task<User> GetById(Guid userId, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    /// <inheritdoc />
    public Task Update(UpdateUserOptions options, CancellationToken cancellationToken)
        => throw new NotImplementedException();
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