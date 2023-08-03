using Application.Common.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infra.Persistence
{
    public class AppDatabaseContext : DbContext, IAppDatabaseContext
    {
        public AppDatabaseContext() { }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();

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
