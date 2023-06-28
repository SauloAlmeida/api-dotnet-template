namespace Domain.Common
{
    public interface IGenericRepository<TEntity> : IRepository
        where TEntity : Entity
    {
        public Task InsertAsync(TEntity entity, CancellationToken ct);
        public Task<TEntity> GetAsync(Guid id, CancellationToken ct);
        public Task DeleteAsync(TEntity entity, CancellationToken ct);
        public Task UpdateAsync(TEntity entity, CancellationToken ct);  
    }
}
