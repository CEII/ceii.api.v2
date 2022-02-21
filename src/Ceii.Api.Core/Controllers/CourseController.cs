using Ceii.Api.Application.Services.Courses;
using Ceii.Api.Application.Services.Courses.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Ceii.Api.Core.Controllers;
[ApiController]
[Route("api/[controller]")]

public class CourseController:ControllerBase
{
    private readonly CourseService _service;

    [HttpGet]
    public async Task<ActionResult<CourseVm>> GetCourseById(int id)
    {
        var course = await _service.GetById(id);
        return course is null ? NotFound() : Ok(course);
    }
}