using Ceii.Api.Application.Common.Interfaces;
using Ceii.Api.Application.Contracts.Inscriptions;
using Ceii.Api.Data.Entities.Inscriptions;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Inscription> Delete(object id)
    {
        var ins = await _ctx.Inscriptions.Where(ins => ins.User!.Email.Equals(id)).FirstOrDefaultAsync();
        _ctx.Inscriptions.Remove(ins);
        await _ctx.SaveChangesAsync(CancellationToken.None);
        return ins;
    }

    public Task<Inscription> Update(Inscription t)
    {
        throw new NotImplementedException();
    }
}