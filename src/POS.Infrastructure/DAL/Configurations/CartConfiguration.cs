using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.DAL.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.UserId);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.HasMany<Item>(x => x.Items)
                .WithOne(x => x.Cart)
                .HasForeignKey(x => x.CartId);
        }
    }
}
