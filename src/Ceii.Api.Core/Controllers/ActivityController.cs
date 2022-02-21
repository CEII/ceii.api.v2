using Ceii.Api.Application.Services.Activities;
using Ceii.Api.Data.Entities.Activities;
using Microsoft.AspNetCore.Mvc;

namespace Ceii.Api.Core.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ActivityController : ControllerBase
{
    private readonly ActivityService _service;

    public ActivityController(ActivityService service)
    {
        _service = service;
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteActivity(int id)
    {
        var activity = await _service.Delete(id);
        
        if (activity is null)
        {
            return NotFound(activity);
        }
        
        return Ok(activity);
    }
}