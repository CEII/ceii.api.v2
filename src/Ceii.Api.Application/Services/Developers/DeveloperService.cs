using AutoMapper;
using Ceii.Api.Application.Contracts.Developers;
using Ceii.Api.Application.Repositories;
using Ceii.Api.Application.Services.Developers.ViewModels;
using Ceii.Api.Data.Entities.Developer;

namespace Ceii.Api.Application.Services.Developers;

public class DeveloperService
{
    private readonly IDeveloperRepository _repository;
    private readonly IMapper _mapper;

    public DeveloperService(IMapper mapper, IDeveloperRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IList<DeveloperVm>> GetAll()
    {
        var devs = await _repository.GetAll();
        return _mapper.Map<IList<Developer>, IList<DeveloperVm>>(devs);
    }

    public async Task<DeveloperVm> GetById(string email)
    {
        var dev = await _repository.GetById(email);
        return _mapper.Map<Developer, DeveloperVm>(dev);
    }
}