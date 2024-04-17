using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.Enums;
using POS.Domain.ValueObjects;

namespace POS.Infrastructure.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, x => new ProductId(x));

            builder.Property(x => x.Name)
                .HasConversion(x => x.Value, x => new ProductName(x))
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Type)
                .HasConversion(x => x.ToString(), x
                    => (ProductType)Enum.Parse(typeof(ProductType), x));

            builder.Property(x => x.Description)
                .HasConversion(x => x.Value, x => new ProductDescription(x));

            builder.Property(x => x.Vendor)
                .HasConversion(x => x.Value, x => new Vendor(x));

            builder.Property(x => x.Price)
                .HasConversion(x => x.Value, x => new ProductPrice(x))
                .IsRequired();

            builder.Property(x => x.Quantity)
                .HasConversion(x => x.Value, x => new ProductQuantity(x))
                .IsRequired();

            builder.Property(x => x.ImageUrl);
        }
    }
}
