using Ceii.Api.Application.Contracts.Activities;
using Ceii.Api.Application.Services.Activities;
using Ceii.Api.Application.Services.Activities.ViewModels;
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
        
    }

    [HttpPost]
    public async Task<ActionResult<ActivityVm>> InsertActivities(Activity activity)
    {
        var activities = await _service.Insert(activity);
        return Ok(activities);
    }
}