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
    public Task<IList<Activity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Activity> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task<Activity> Insert(Activity t)
    {
        throw new NotImplementedException();
    }

    public Task<Activity> Delete(object id)
    {
        throw new NotImplementedException();
    }

    public Task<Activity> Update(Activity t)
    {
        throw new NotImplementedException();
    }
} 
