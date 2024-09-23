using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Interfaces;

public interface IRepository<TEntity, in TKey>
    where TEntity : BaseEntity<TKey>
    where TKey : struct
{
    Task<TEntity?> GetByIdAsync(TKey id, bool isTracking = false);

    void Add(TEntity entity);

    void AddRange(IEnumerable<TEntity> entities);

    void Delete(TEntity entity);

    void DeleteRange(IEnumerable<TEntity> entities);

    Task SaveChangesAsync();
}