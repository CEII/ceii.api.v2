using Ceii.Api.Data.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Ceii.Api.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    
    DbSet<Role> Roles { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken? cancellationToken);
}