namespace Ceii.Api.Data.Entities.Users;

public class User
{
    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? Password { get; set; }

    public string? ImageUrl { get; set; }

    public Role? Role { get; set; }
    
    public Guid? PasswordRecovery { get; set; }

    
}