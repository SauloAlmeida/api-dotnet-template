using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infra.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDatabaseContext _context;

        public UserRepository(AppDatabaseContext context) 
            => _context = context;

        public async Task InsertAsync(User entity, CancellationToken ct) 
            => await _context.AddAsync(entity, ct);

        public async Task<User> GetAsync(Guid id, CancellationToken ct) 
            => await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id, ct);

        public Task UpdateAsync(User entity, CancellationToken _) 
            => Task.FromResult(_context.Users.Update(entity));
        
        public Task DeleteAsync(User entity, CancellationToken ct)
            => Task.FromResult(_context.Users.Remove(entity));   
    }
}
