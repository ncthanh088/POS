using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.ValueObjects;

namespace POS.Infrastructure.DAL.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, x => new CartId(x));

            builder.Property(x => x.UserId)
                .HasConversion(x => x.Value, x => new UserId(x));

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.HasMany<Item>(x => x.Items)
                .WithOne(x => x.Cart)
                .HasForeignKey(x => x.CartId);
        }
    }
}
