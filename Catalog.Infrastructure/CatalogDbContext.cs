using System.Data.Common;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Catalog.Infrastructure;

public class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();
    
    public DbSet<Item> Items => Set<Item>();

    public static DbDataSource BuildDataSource(string connectionString)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
        
        return dataSourceBuilder.Build();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CatalogConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
    }
}