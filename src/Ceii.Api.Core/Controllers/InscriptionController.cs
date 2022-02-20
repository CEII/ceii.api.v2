using Ceii.Api.Application.Services.Inscriptions;
using Ceii.Api.Application.Services.Inscriptions.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ceii.Api.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InscriptionController : ControllerBase
{
    private readonly InscriptionService _service;

    public InscriptionController(InscriptionService service)
    {
        _service = service;
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(string id)
    {
        var ins = await _service.Delete(id);
        return ins is null ? NotFound() : Ok(ins);
    }
}