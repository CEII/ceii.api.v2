using Ceii.Api.Application.Services.Inscriptions;
using Ceii.Api.Application.Services.Inscriptions.ViewModels;
using Ceii.Api.Data.Entities.Inscriptions;
using Microsoft.AspNetCore.Mvc;

namespace Ceii.Api.Core.Controllers;

[ApiController]
[Route("api/[controller]")]

public class InscriptionController:ControllerBase
{
    private readonly InscriptionService _service;
    
    public InscriptionController(InscriptionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<InscriptionVm>>
        InsertInscription(Inscription inscription)
    {
        var ins = await _service.Insert(inscription);
        return Ok(ins);
    }
}