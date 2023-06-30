using Application.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infra.Persistence
{
    public class AppDatabaseContext : DbContext, IAppDatabaseContext
    {
        public DbSet<User> Users => Set<User>();

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
