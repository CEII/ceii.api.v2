using AutoMapper;
using Ceii.Api.Application.Repositories;

namespace  Ceii.Api.Application.Services.Activities;

public class ActivityService
{
    private readonly ActivityRepository _repository;
    private readonly IMapper _mapper;

    public ActivityService(ActivityRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
}
