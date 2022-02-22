using Ceii.Api.Data.Entities.Users;

namespace Ceii.Api.Application.Services.Inscriptions.ViewModels;

public class InscriptionVm
{
    public string? Occupation { get; set; }
    
    public string? Description { get; set; }
    
    public User? UserEmail { get; set; }
}