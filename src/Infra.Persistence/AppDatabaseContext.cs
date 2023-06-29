using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infra.Persistence
{
    public class AppDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
