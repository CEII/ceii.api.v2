using AutoMapper;
using Ceii.Api.Application.Contracts.Inscriptions;
using Ceii.Api.Application.Repositories;
using Ceii.Api.Data.Entities.Inscriptions;

namespace  Ceii.Api.Application.Services.Inscriptions;

public class InscriptionService
{
    private readonly InscriptionRepository _repository;
    private readonly IMapper _mapper;

    public InscriptionService(InscriptionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<Inscription> Delete(string id)
    {
        var ins = await _repository.Delete(id);
        return ins;
    }
}

