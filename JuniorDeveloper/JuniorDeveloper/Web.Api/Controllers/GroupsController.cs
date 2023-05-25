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
    public IActionResult Delete(Guid groupId, CancellationToken cancellationToken)
    {
        _groupService.Delete(groupId);

        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var groups = _groupService.GetAll();

        return Ok(groups);
    }

    [HttpGet("{groupId:guid}")]
    public IActionResult GetById(Guid groupId)
    {
        var group = _groupService.GetById(groupId);

        return Ok(group);
    }

    [HttpPatch]
    public IActionResult Update(UpdateGroupRequest request)
    {
        _groupService.Update(new UpdateGroupOptions
        {
            GroupId = request.GroupId,
            Name = request.Name,
        });

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