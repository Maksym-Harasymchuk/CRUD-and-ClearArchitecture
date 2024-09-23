using Catalog.Application.Common.Interfaces;
using Catalog.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddDalServiceExtensions(this IServiceCollection services)
    {
        services.AddDbContext<CatalogDbContext>(options =>
        {
            var connectionString = "server=localhost; port=5432; uid=postgres; password=postgres; database=catalog";
            options.UseNpgsql(connectionString);
        });

        return services;
    }

    public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //var connectionString = configuration.GetConnectionString("DefaultConnection");
        var connectionString = "server=localhost; port=5432; uid=postgres; password=postgres; database=catalog";

        var dataSource = CatalogDbContext.BuildDataSource(connectionString);
        var dbOptionsAction = new Action<DbContextOptionsBuilder>(options => options.UseNpgsql(dataSource,
            builder => builder.MigrationsAssembly(typeof(CatalogDbContext).Assembly.FullName)));

        services.AddDbContext<CatalogDbContext>(dbOptionsAction);
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        /*services.AddDbContext<CatalogDbContext>(options =>
        {

            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Infrastructure"));
        });
        // double check DBcontext
        services.AddScoped<CatalogDbContext>(provider => provider.GetRequiredService<CatalogDbContext>());
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ApplicationDbContextInitializer>();*/
    }
}