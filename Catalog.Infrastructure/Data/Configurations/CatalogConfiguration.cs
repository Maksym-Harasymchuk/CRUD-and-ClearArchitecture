using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Data.Configurations;

public class CatalogConfiguration : BaseEntityConfiguration<Domain.Entities.Category, int>
{
    public override void Configure(EntityTypeBuilder<Domain.Entities.Category> builder)
    {
        base.Configure(builder);
        
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.ToTable("Categories");
    }
}