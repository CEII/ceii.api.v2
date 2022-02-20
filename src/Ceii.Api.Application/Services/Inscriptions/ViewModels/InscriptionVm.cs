
using Ceii.Api.Application.Services.Users.ViewModels;

namespace Ceii.Api.Application.Services.Inscriptions.ViewModels;

public class InscriptionVm
{
    public UserVm? User { get; set; }
    
    // public List<Activity>? Activity { get; set; }
    
    public DateTime? CreatedAt { get; set; }
}