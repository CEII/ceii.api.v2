using AutoMapper;
using Ceii.Api.Application.Contracts.Inscriptions;
using Ceii.Api.Application.Services.Inscriptions.ViewModels;
using Ceii.Api.Data.Entities.Inscriptions;

namespace  Ceii.Api.Application.Services.Inscriptions;

public class InscriptionService
{
    private readonly IInscriptionRepository _repository;
    private readonly IMapper _mapper;

    public InscriptionService(IInscriptionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IList<InscriptionVm>> GetAll()
    {
        var inscriptions = await _repository.GetAll();
        return _mapper.Map<IList<Inscription>, IList<InscriptionVm>>(inscriptions);
    }
}

