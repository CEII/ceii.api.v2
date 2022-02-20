using Ceii.Api.Application.Services.Developers;
using Ceii.Api.Application.Services.Developers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ceii.Api.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeveloperController:ControllerBase
{
    private readonly DevelopersServices _service;

    public DeveloperController(DevelopersServices service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IList<DeveloperVm>>> GetAllDevelopers()
    {
        var devs = await _service.GetAll();
        return Ok(devs);
    }
}