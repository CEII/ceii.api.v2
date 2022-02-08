using Ceii.Api.Application.Common.Interfaces;
using Ceii.Api.Application.Contracts.Activities;
using Ceii.Api.Data.Entities.Activities;

namespace Ceii.Api.Application.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly IApplicationDbContext _ctx;

    public ActivityRepository(IApplicationDbContext ctx)
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
