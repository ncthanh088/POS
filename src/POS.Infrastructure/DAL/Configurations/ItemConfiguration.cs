using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.DAL.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CartId);

            builder.Property(x => x.ProductId);

            builder.Property(x => x.ProductName);

            builder.Property(x => x.ImageUrl);

            builder.Property(x => x.UnitPrice);

            builder.Property(x => x.Quantity);
        }
    }
}
