using Ceii.Api.Data.Entities.Users;

namespace Ceii.Api.Data.Entities.Developers;

public class Developer
{
    public int Id { get; set; }
    
    public User? User { get; set; }
    
    public string? Participation { get; set; }
    
    public DateTime? AddedAt { get; set; }
}