using Ceii.Api.Application.Common.Interfaces;
using Ceii.Api.Application.Contracts.Developers;
using Ceii.Api.Data.Entities.Developers;
using Microsoft.EntityFrameworkCore;

namespace Ceii.Api.Application.Repositories;

public class DeveloperRespository : IDeveloperRepository
{

    private readonly IApplicationDbContext _ctx;

    public DeveloperRespository(IApplicationDbContext ctx)
    {
        _ctx = ctx;
    }


    public Task<IList<Developer>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Developer> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task<Developer> Insert(Developer t)
    {
        throw new NotImplementedException();
    }

    public async Task<Developer> Delete(object id)
    {
        var dev = await _ctx.Developers.Where(dev => dev.User!.Email.Equals(id)).FirstOrDefaultAsync();
        _ctx.Developers.Remove(dev);
        await _ctx.SaveChangesAsync(CancellationToken.None);
        return dev;
    }

    public Task<Developer> Update(Developer t)
    {
        throw new NotImplementedException();
    }
}