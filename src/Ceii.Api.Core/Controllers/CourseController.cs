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

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var courses = await _service.GetAll();
        return Ok(courses); 
    }
}