using System.Reflection;
using Ceii.Api.Data.Entities.Inscriptions;
using Ceii.Api.Data.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Ceii.Api.Data.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    
    public DbSet<Role>? Roles { get; set; }
    
    public DbSet<Profile>? Profiles { get; set; }

    public DbSet<Inscription>? Inscriptions { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}