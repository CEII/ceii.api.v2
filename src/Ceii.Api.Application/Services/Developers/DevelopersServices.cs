using AutoMapper;
using Ceii.Api.Application.Repositories;
using Ceii.Api.Application.Services.Developers.ViewModels;
using Ceii.Api.Data.Entities.Developers;

namespace Ceii.Api.Application.Services.Developers;

public class DevelopersServices
{
    private readonly DeveloperRespository _repository;
    private readonly IMapper _mapper;

    public DevelopersServices(IMapper mapper, DeveloperRespository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<DeveloperVm> GetById(string email)
    {
        var dev = await _repository.GetById(email);
        return _mapper.Map<Developer,DeveloperVm>(dev);
    }
} 