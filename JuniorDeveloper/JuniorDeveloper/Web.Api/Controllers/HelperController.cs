using Infrastructure.Persistence.DemoData;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class HelperController : ControllerBase
{
    private readonly IDemoDataService _demoDataService;

    public HelperController(IDemoDataService demoDataService)
    {
        _demoDataService = demoDataService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ResetDemoData(CancellationToken cancellationToken)
    {
        await _demoDataService.ResetDatabaseData(cancellationToken);

        return Ok();
    }
}
