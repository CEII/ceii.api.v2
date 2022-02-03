using Ceii.Api.Data.Entities.Users;
using Ceii.Api.Data.Entities.Activities;

namespace Ceii.Api.Data.Entities.Inscriptions;

public class Inscription
{
    public int Id { get; set; }
    
    public List<User>? User { get; set; }
    
    // public List<Activity>? Activity { get; set; }
    
    public DateTime? CreatedAt { get; set; }
}
