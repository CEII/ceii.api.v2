using Ceii.Api.Application.Services.Courses;
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

    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var course = await _service.Delete(id);
        return course is null ? NotFound() : Ok();
    }
}
