using Ceii.Api.Application.Services.Category.ViewModels;
using Ceii.Api.Data.Enums;

namespace Ceii.Api.Application.Services.Activities.ViewModels;

public class ActivityVm
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? Quota { get; set; }

    public bool? Enabled { get; set; }

    public ActivityModeEnum? Mode { get; set; }

    public string? InvitationLink { get; set; }

    public CategoryVm? Category { get; set; }
}