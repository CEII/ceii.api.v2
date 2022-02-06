using Ceii.Api.Data.Enums;

namespace Ceii.Api.Data.Entities.Activities;

public class Activity
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? Quota { get; set; }

    public bool? Enabled { get; set; }

    public ActivityModeEnum? Mode { get; set; }

    public string? InvitationLink { get; set; }

    public Category? CategoryId { get; set; }
}