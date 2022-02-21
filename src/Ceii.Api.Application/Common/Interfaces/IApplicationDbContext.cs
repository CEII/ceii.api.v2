using Ceii.Api.Data.Entities.Developers;
using Ceii.Api.Data.Entities.Activities;
using Ceii.Api.Data.Entities.Inscriptions;
using Ceii.Api.Data.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Profile = Ceii.Api.Data.Entities.Users.Profile;

namespace Ceii.Api.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    
    DbSet<Role> Roles { get; set; }
    
    DbSet<Profile> Profiles { get; set; }

    DbSet<Inscription> Inscriptions { get; set; }
    
    DbSet<Developer> Developers { get; set; }

    DbSet<Activity> Activities { get; set; }
    
    DbSet<Course> Courses  { get; set; }

    Task<int> SaveChangesAsync(CancellationToken? cancellationToken);
}