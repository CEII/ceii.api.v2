using Ceii.Api.Application.Services.Courses;
using Ceii.Api.Data.Entities.Activities;
using Microsoft.AspNetCore.Mvc;

namespace Ceii.Api.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly CourseService _service;

    public CourseController(CourseService service)
    {
        _service = service;
    }

    [HttpPut]
    public async Task<ActionResult> Update(Course updatedCourse)
    {
        var course = await _service.Update(updatedCourse);
        return course is null ? NotFound() : Ok();
    }
}
