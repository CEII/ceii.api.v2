namespace Ceii.Api.Data.Entities.Activities;

public class Course : Activity
{
    public DateTime? StartstAt { get; set; }

    public DateTime? EndsAt { get; set; }

    public int Days { get; set; }

    public int Duration { get; set; }
}