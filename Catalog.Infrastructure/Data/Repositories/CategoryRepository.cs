using Catalog.Application.Common.Interfaces;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Data.Repositories;

public class CategoryRepository(CatalogDbContext dbContext) : Repository<Category, int>(dbContext), ICategoryRepository
{
    public async Task<List<Domain.Entities.Category>> GetCategoriesAsync()
    {
        return await GetDbSet(false).ToListAsync();
    }
}