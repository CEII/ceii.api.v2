using Ceii.Api.Data.Entities.Users;

namespace Ceii.Api.Data.Entities.New;

public class Profile
{
    public int Id { get; set; }
    public string? Occupation { get; set; }
    public string? Description { get; set; }
    public User? UserEmail { get; set; }

}
