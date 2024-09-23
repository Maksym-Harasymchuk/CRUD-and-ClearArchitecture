using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Data.Configurations;

public class ItemConfiguration : BaseEntityConfiguration<Item, int>
{
    public override void Configure(EntityTypeBuilder<Item> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(x => x.Amount);

        builder
            .ToTable(
                "Items",
                t => t.HasCheckConstraint("CK_PositiveNumber", """
                                                               "Amount" > 0
                                                               """));
    }
}