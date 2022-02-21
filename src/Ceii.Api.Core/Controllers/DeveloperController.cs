using Ceii.Api.Application.Services.Developers;
using Ceii.Api.Application.Services.Developers.ViewModels;
using Ceii.Api.Data.Entities.Developers;
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
    
    [HttpPost]
    public async Task<ActionResult<DeveloperVm>> InsertDeveloper(Developer developer)
    {
        var dev = await _service.Insert(developer);
        return Ok(dev);
    }
    
}