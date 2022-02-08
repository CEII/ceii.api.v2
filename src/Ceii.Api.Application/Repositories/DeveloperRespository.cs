using Ceii.Api.Application.Common.Interfaces;
using Ceii.Api.Application.Contracts.Developers;
using Ceii.Api.Data.Entities.Developers;

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

    public Task<Developer> Delete(object id)
    {
        throw new NotImplementedException();
    }

    public Task<Developer> Update(Developer t)
    {
        throw new NotImplementedException();
    }
}