using Catalog.Application.Common.Interfaces;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Data.Repositories;

public class Repository<TEntity, TKey>(CatalogDbContext dbContext) : IRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
    where TKey : struct
{
    public async Task<TEntity?> GetByIdAsync(TKey id, bool isTracking = false)
    {
        var entity = await GetDbSet(isTracking)
            .FirstOrDefaultAsync(entity => entity.Id.Equals(id));

        return entity;
    }

    public void Add(TEntity entity)
    {
        dbContext.Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        dbContext.AddRange(entities);
    }

    public void Delete(TEntity entity)
    {
        dbContext.Remove(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        dbContext.RemoveRange(entities);
    }

    protected virtual IQueryable<TEntity> GetDbSet(bool isTracking = false)
    {
        IQueryable<TEntity> set = dbContext.Set<TEntity>();

        if (!isTracking)
        {
            set = set.AsNoTracking();
        }

        return set;
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}