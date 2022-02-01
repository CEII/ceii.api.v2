using Ceii.Api.Application.Services.Users;
using Ceii.Api.Application.Services.Users.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ceii.Api.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IList<UserVm>>> GetAllUsers()
    {
        var users = await _service.GetAll();
        return Ok(users);
    }
}