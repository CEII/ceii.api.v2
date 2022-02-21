using AutoMapper;
using Ceii.Api.Application.Contracts.Activities;
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

    public async Task<Activity> Delete(int id)
    {
        var activity = await _repository.Delete(id);
        return activity;
    }
}
