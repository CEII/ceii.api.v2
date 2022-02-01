using Ceii.Api.Application.Contracts.Users;
using Ceii.Api.Data.Context;
using Ceii.Api.Data.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Ceii.Api.Application.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _ctx;

    public UserRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IList<User>> GetAll()
    {
        var users = await _ctx.Users!
            .OrderBy(usr => usr.Email)
            .ToListAsync();

        return users;
    }

    public async Task<User> GetById(object id)
    {
        return (await _ctx.Users!.Where(usr => usr.Email!.Equals(id as string)).FirstOrDefaultAsync())!;
    }

    public Task<User> Insert(User t)
    {
        throw new NotImplementedException();
    }

    public Task<User> Delete(object id)
    {
        throw new NotImplementedException();
    }

    public Task<User> Update(User t)
    {
        throw new NotImplementedException();
    }
}