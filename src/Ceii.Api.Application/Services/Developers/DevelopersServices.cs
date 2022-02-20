using AutoMapper;
using Ceii.Api.Application.Contracts.Developers;
using Ceii.Api.Application.Repositories;
using Ceii.Api.Data.Entities.Developers;

namespace Ceii.Api.Application.Services.Developers;

public class DevelopersServices
{
    private readonly IDeveloperRepository _repository;
    private readonly IMapper _mapper;

    public DevelopersServices(IMapper mapper, IDeveloperRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Developer> Delete(string email)
    {
        var dev = await _repository.Delete(email);
        return dev;
    }
} 