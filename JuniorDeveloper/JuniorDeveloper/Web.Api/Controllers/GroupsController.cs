using Application.Groups;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Web.Api.Controllers;

[ApiController]
[ResponseCache(NoStore = true, Duration = 0)]
[OutputCache(NoStore = true, Duration = 0)]
[Route("/api/[controller]")]
public class GroupsController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupsController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddGroupRequest request, CancellationToken cancellationToken)
    {
        await _groupService.Add(Domain.Group.Create(Guid.NewGuid(), request.Name), cancellationToken);

        return Ok();
    }

    [HttpDelete("{groupId:guid}")]
    public async Task<IActionResult> Delete(Guid groupId, CancellationToken cancellationToken)
    {
        await _groupService.Delete(groupId, cancellationToken);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var groups = await _groupService.GetAll(cancellationToken);

        return Ok(groups);
    }

    [HttpGet("{groupId:guid}")]
    public async Task<IActionResult> GetById(Guid groupId, CancellationToken cancellationToken)
    {
        var group = await _groupService.GetById(groupId, cancellationToken);

        return Ok(group);
    }

    [HttpPatch]
    public async Task<IActionResult> Update(UpdateGroupRequest request, CancellationToken cancellationToken)
    {
        await _groupService.Update(new UpdateGroupOptions
        {
            GroupId = request.GroupId,
            Name = request.Name,
        }, cancellationToken);

        return Ok();
    }
}

public class AddGroupRequest
{
    public required string Name { get; init; }
}

public class UpdateGroupRequest
{
    public required string Name { get; init; }

    public required Guid GroupId { get; init; }
}