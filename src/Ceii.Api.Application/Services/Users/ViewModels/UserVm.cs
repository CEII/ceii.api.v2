namespace Ceii.Api.Application.Services.Users.ViewModels;

public class UserVm
{
    public string? Email { get; set; }
    
    public string? Name { get; set; }
    
    public string? LastName { get; set; }
    
    public string? ImageUrl { get; set; }
    
    public string? Role { get; set; }

    public Guid? PasswordRecover { get; set; }
}