using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Data.Repositories;

public class ItemRepository(CatalogDbContext dbContext) : Repository<Item, int>(dbContext)
{
}