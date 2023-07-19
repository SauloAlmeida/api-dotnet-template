using Domain.Entity;

namespace Application.Common.Interfaces
{
    public interface IAppDatabaseContext
    {
        DbSet<User> Users { get; }

        public Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
