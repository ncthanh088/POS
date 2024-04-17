using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore
    .Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.ValueObjects;

namespace POS.Infrastructure.DAL.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CartId)
                .HasConversion(x => x.Value, x => new CartId(x));

            builder.Property(x => x.ProductId)
                .HasConversion(x => x.Value, x => new ProductId(x));

            builder.Property(x => x.ProductName)
                .HasConversion(x => x.Value, x => new ProductName(x));

            builder.Property(x => x.ImageUrl);

            builder.Property(x => x.UnitPrice);

            builder.Property(x => x.Quantity);
        }
    }
}
