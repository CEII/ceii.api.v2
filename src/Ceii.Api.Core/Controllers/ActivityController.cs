using Ceii.Api.Application.Services.Activities;
using Ceii.Api.Application.Services.Activities.ViewModels;
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

    [HttpGet]
    public async Task<ActionResult<IList<ActivityVm>>> GetAllActivities()
    {
        var activities = await _service.GetAll();
        return Ok(activities);
    }
}