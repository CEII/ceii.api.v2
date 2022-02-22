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

    public async  Task<Inscription> Insert(Inscription t)
    {
        var ins = new Inscription()
        {
            Id = t.Id,
            User = t.User,
            CreatedAt = t.CreatedAt
        };
        _ctx.Inscriptions.Add(ins);

        await _ctx.SaveChangesAsync(null);
        return ins;

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