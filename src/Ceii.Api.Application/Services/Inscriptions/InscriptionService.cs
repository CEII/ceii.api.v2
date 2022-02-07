using AutoMapper;
using Ceii.Api.Application.Repositories;

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
}

