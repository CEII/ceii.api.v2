using Ceii.Api.Data.Entities.Users;

namespace Ceii.Api.Data.Entities.SocialNetworks;

public class SocialNetwork
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Link { get; set; }
    public List<User>? User { get; set; }
}