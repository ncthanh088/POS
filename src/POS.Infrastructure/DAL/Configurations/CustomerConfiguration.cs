using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.ValueObjects;

namespace POS.Infrastructure.DAL.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.CustomerId);
            builder.Property(x => x.CustomerId)
                .HasConversion(x => x.Value, x => new UserId(x));

            builder.Property(x => x.FirstName)
                .HasConversion(x => x.Value, x => new FirstName(x))
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .HasConversion(x => x.Value, x => new LastName(x))
                .HasMaxLength(100);

            builder.Property(x => x.Phone)
                .HasConversion(x => x.Value, x => new Phone(x))
                .HasMaxLength(20);

            builder.Property(x => x.Address)
                .HasConversion(x => x.Value, x => new Address(x));
        }
    }
}
