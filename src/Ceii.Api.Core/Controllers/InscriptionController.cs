using Ceii.Api.Application.Services.Developers;
using Ceii.Api.Application.Services.Inscriptions.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ceii.Api.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeveloperController : ControllerBase
{
    private readonly DevelopersServices _service;

    public DeveloperController(DevelopersServices service)
    {
        _service = service;
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(string id)
    {
        var dev = await _service.Delete(id);
        return dev is null ? NotFound() : Ok();
    }
}