using AutoMapper;
using Ceii.Api.Application.Contracts.Activities;
using Ceii.Api.Application.Services.Activities.ViewModels;
using Ceii.Api.Data.Entities.Activities;

namespace  Ceii.Api.Application.Services.Activities;

public class ActivityService
{
    private readonly IActivityRepository _repository;
    private readonly IMapper _mapper;

    public ActivityService(IMapper mapper, IActivityRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<IList<ActivityVm>> GetAll()
    {
        var activities = await _repository.GetAll();
        return _mapper.Map<IList<Activity>, IList<ActivityVm>>(activities);
    }
}
