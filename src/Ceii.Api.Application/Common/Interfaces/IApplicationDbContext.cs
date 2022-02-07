using Ceii.Api.Data.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Profile = AutoMapper.Profile;

namespace Ceii.Api.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    
    DbSet<Role> Roles { get; set; }
    
    DbSet<Profile> Profiles { get; set; }

    Task<int> SaveChangesAsync(CancellationToken? cancellationToken);
}