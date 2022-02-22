using AutoMapper;
using Ceii.Api.Application.Repositories;
using Ceii.Api.Application.Services.Inscriptions.ViewModels;
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
    

    public async Task<InscriptionVm> Insert(Inscription inscription)
    {
        var ins = await _repository.Insert(inscription);
        return _mapper.Map<Inscription, InscriptionVm>(ins);
    }
}

