using AutoMapper;
using Ceii.Api.Application.Services.Activities.ViewModels;
using Ceii.Api.Data.Entities.Activities;

namespace Ceii.Api.Application.Services.Activities;

public class ActivityMappings : Profile
{
    public ActivityMappings()
    {
        CreateMap<Activity, ActivityVm>();
        CreateMap<ActivityVm, Activity>();
    }
}
