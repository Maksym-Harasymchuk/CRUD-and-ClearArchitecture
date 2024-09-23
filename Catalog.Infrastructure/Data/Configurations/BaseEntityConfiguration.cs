using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Data.Configurations;

public class BaseEntityConfiguration <TEntity, TEntityKey>  : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity<TEntityKey>
    where TEntityKey : struct
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
    }
}