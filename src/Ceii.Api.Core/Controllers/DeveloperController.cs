using Ceii.Api.Application.Services.Developers;
using Ceii.Api.Application.Services.Developers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ceii.Api.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeveloperController : ControllerBase
{
    private readonly DeveloperService _service;

    public DeveloperController(DeveloperService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IList<DeveloperVm>>> GetAllDevelopers()
    {
        var devs = await _service.GetAll();
        return Ok(devs);
    }

    [HttpGet("{id:string}")]
    public async Task<ActionResult<DeveloperVm>> GetDeveloperById(string id)
    {
        var dev = await _service.GetById(id);
        return dev is null ? NotFound() : Ok(dev);
    }
}