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

    [HttpGet]
    public async Task<ActionResult<IList<InscriptionVm>>> GetAllInscriptions()
    {
        var inscriptions = await _service.GetAll();
        return Ok(inscriptions);
    }
}