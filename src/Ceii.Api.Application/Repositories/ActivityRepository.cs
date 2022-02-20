using Ceii.Api.Application.Common.Interfaces;
using Ceii.Api.Application.Contracts.Activities;
using Ceii.Api.Data.Entities.Activities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Activity> Insert(Activity t)
    {
        var activity = new Activity()
        {
            Id = new Activity().Id,
            Title = new Activity().Title,
            Description = new Activity().Description,
            Quota = new Activity().Quota,
            Enabled = new Activity().Enabled,
            Mode = new Activity().Mode,
            InvitationLink = new Activity().InvitationLink,
            CategoryId = new Activity().CategoryId
        };

        _ctx.Activities.Add(activity);
        await _ctx.SaveChangesAsync(null);
        
        return activity;
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
