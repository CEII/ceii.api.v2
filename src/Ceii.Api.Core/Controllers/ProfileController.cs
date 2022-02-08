using Ceii.Api.Application.Services.Profiles;
using Ceii.Api.Application.Services.Profiles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ceii.Api.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly ProfileService _service;

    public ProfileController(ProfileService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IList<ProfileVm>>> GetAllProfiles()
    {
        var profiles = await _service.GetAll();
        return Ok(profiles);
    }
}