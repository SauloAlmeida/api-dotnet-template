using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IAppDatabaseContext
    {
        DbSet<User> Users { get; }

        public Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
