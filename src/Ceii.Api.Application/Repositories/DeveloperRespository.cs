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

    public async  Task<Developer> Insert(Developer t)
    {
        var dev =  new Developer()
        {
            Id=t.Id,
            User=t.User,
            Participation = t.Participation,
            AddedAt = t.AddedAt
        };
        
        _ctx.Developers.Add(dev);
        await _ctx.SaveChangesAsync(null);

        return dev; 
    }
    

    public Task<Developer> Delete(object id)
    {
        throw new NotImplementedException();
    }

    public Task<Developer> Update(Developer t)
    {
        throw new NotImplementedException();
    }
}