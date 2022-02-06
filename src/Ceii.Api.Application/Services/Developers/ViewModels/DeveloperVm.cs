using Ceii.Api.Application.Services.Users.ViewModels;

namespace Ceii.Api.Application.Services.Developers.ViewModels;

public class DeveloperVm
{
    public UserVm? User { get; set; }
    
    public string? Participation { get; set; }
    
    public DateTime? AddedAt { get; set; }
}