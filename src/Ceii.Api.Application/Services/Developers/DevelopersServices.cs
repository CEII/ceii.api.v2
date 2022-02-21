using AutoMapper;
using Ceii.Api.Application.Contracts.Developers;
using Ceii.Api.Application.Repositories;
using Ceii.Api.Application.Services.Developers.ViewModels;
using Ceii.Api.Data.Entities.Developers;

namespace Ceii.Api.Application.Services.Developers;

public class DevelopersServices
{
    private readonly IDeveloperRepository _respository;

    private readonly IMapper _mapper;

    public DevelopersServices(IMapper mapper, IDeveloperRepository repository)
    {
        _mapper = mapper;
        _respository = repository;
    }

    public async Task<DeveloperVm> Insert(Developer developer)
    {
        var dev = await _respository.Insert(developer);
        
        return _mapper.Map<Developer,DeveloperVm>(dev); 
    }
} 