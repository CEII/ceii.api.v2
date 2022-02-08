using System.Reflection;
using Ceii.Api.Data.Entities.Developers;
using Ceii.Api.Data.Entities.Inscriptions;
using Ceii.Api.Data.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Ceii.Api.Data.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    
    public DbSet<Role> Roles => Set<Role>();

    public DbSet<Inscription> Inscriptions => Set<Inscription>();

    public DbSet<Developer> Developers => Set<Developer>();

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}