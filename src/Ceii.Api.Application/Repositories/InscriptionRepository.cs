using Ceii.Api.Application.Common.Interfaces;
using Ceii.Api.Application.Contracts.Inscriptions;
using Ceii.Api.Data.Entities.Inscriptions;

namespace Ceii.Api.Application.Repositories;

public class InscriptionRepository : IInscriptionRepository
{
    private readonly IApplicationDbContext _ctx;

    public InscriptionRepository(IApplicationDbContext ctx)
    {
        _ctx = ctx;
    }
    public Task<IList<Inscription>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Inscription> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task<Inscription> Insert(Inscription t)
    {
        throw new NotImplementedException();
    }

    public Task<Inscription> Delete(object id)
    {
        throw new NotImplementedException();
    }

    public Task<Inscription> Update(Inscription t)
    {
        throw new NotImplementedException();
    }
}