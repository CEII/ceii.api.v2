using Ceii.Api.Application.Services.Users.ViewModels;

namespace Ceii.Api.Application.Services.Profiles.ViewModels;

public class ProfileVm
{
    public string? Occupation { get; set; }
    
    public string? Description { get; set; }
    
    public UserVm? User { get; set; }
}