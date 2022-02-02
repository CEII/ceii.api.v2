using Ceii.Api.Data.Entities.Users;

namespace Ceii.Api.Data.Entities.New;

public class New
{
    public string? Code { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Markdown { get; set; }
    public List<User>? User { get; set; }
}