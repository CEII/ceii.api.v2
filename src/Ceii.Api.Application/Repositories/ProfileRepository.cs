using Ceii.Api.Application.Common.Interfaces;
using Ceii.Api.Application.Contracts.Profiles;
using Ceii.Api.Data.Entities.Users;

namespace Ceii.Api.Application.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly IApplicationDbContext _ctx;

    public ProfileRepository(IApplicationDbContext ctx)
    {
        _ctx = ctx;
    }
    public Task<IList<Profile>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Profile> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task<Profile> Insert(Profile t)
    {
        throw new NotImplementedException();
    }

    public Task<Profile> Delete(object id)
    {
        throw new NotImplementedException();
    }

    public Task<Profile> Update(Profile t)
    {
        throw new NotImplementedException();
    }
}