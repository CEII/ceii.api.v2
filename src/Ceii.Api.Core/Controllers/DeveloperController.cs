using Ceii.Api.Application.Services.Developers;
using Ceii.Api.Application.Services.Developers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ceii.Api.Core.Controllers;

[ApiController]
[Route("api/[Controller]")]

public class DeveloperController: ControllerBase
{
    private readonly DevelopersServices _service;

    public DeveloperController(DevelopersServices service)
    {
        _service = service;
    }

    [HttpGet("{id:string}")]
    public async Task<ActionResult<DeveloperVm>> GetDeveloperById(string id)
    {
        var dev = await _service.GetById(id);
        return dev is null ? NotFound() : Ok(dev);
    }

}