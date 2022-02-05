using Ceii.Api.Data.Entities.Users;

namespace Ceii.Api.Data.Entities.Inscriptions;

public class Inscription
{
    public int Id { get; set; }
    
    public List<User>? User { get; set; }
    
    // public List<Activity>? Activity { get; set; }
    
    public DateTime? CreatedAt { get; set; }
}
