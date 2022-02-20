using AutoMapper;
using Ceii.Api.Application.Contracts.Activities;
using Ceii.Api.Application.Repositories;
using Ceii.Api.Application.Services.Activities.ViewModels;
using Ceii.Api.Data.Entities.Activities;

namespace  Ceii.Api.Application.Services.Activities;

public class ActivityService
{
    private readonly IActivityRepository _repository;
    private readonly IMapper _mapper;

    public ActivityService(IActivityRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ActivityVm> Insert(Activity activity)
    {
        var activities = await _repository.Insert(activity);
        return _mapper.Map<Activity, ActivityVm>(activities);
    }
}
