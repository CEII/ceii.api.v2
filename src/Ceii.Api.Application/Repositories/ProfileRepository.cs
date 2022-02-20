using Ceii.Api.Application.Common.Interfaces;
using Ceii.Api.Application.Contracts.Profiles;
using Ceii.Api.Data.Entities.Users;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using UserProfile = Ceii.Api.Data.Entities.Users.Profile;

namespace Ceii.Api.Application.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly IApplicationDbContext _ctx;

    public ProfileRepository(IApplicationDbContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task<IList<Profile>> GetAll()
    {
        var profiles = await _ctx.Profiles.ToListAsync();

        return profiles;
    }

    public async Task<Profile> GetById(object id)
    {
        var profiles = await _ctx.Profiles.Where(prof => prof.UserEmail.Equals(id)).FirstOrDefaultAsync();
        return profiles;
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