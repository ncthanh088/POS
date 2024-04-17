using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.ValueObjects;

namespace POS.Infrastructure.DAL.Configurations
{
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, x => new OrderId(x));

            builder.Property(x => x.UserId)
                .HasConversion(x => x.Value, x => new UserId(x));

            builder.Property(x => x.Currency)
                .HasConversion(x => x.Value, x => new Currency(x))
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.TotalAmount)
                .HasConversion(x => x.Value, x => new OrderTotalAmount(x));
        }
    }
}
