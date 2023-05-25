using Application.Users;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[ApiController]
[ResponseCache(NoStore = true)]
[Route("/api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddUserRequest request, CancellationToken cancellationToken)
    {
        await _userService.Add(Domain.User.Create(Guid.NewGuid(), request.Email), cancellationToken);

        return Ok();
    }

    [HttpDelete("{userId:guid}")]
    public async Task<IActionResult> Delete(Guid userId, CancellationToken cancellationToken)
    {
        await _userService.Delete(userId, cancellationToken);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var users = await _userService.GetAll(cancellationToken);

        return Ok(users);
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetById(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _userService.GetById(userId, cancellationToken);

        return Ok(user);
    }

    [HttpPatch]
    public async Task<IActionResult> Update(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        await _userService.Update(new UpdateUserOptions
        {
            Email = request.Email,
            UserId = request.UserId
        },
        cancellationToken);

        return Ok();
    }
}

public class AddUserRequest
{
    public required string Email { get; init; }
}

public class UpdateUserRequest
{
    public required string Email { get; init; }

    public required Guid UserId { get; init; }
}