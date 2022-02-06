namespace Ceii.Api.Data.Entities.Activity;

public class Activity
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? Quota { get; set; }

    public bool? Enabled { get; set; }

    public enum Mode
    {
        Online,
        Classroom
    }

    public string? InvitationLink { get; set; }

    public Category.Category? CategoryId { get; set; }
}