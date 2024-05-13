using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.DAL.Configurations
{
    class SaleTransactionConfiguration : IEntityTypeConfiguration<SaleTransaction>
    {
        public void Configure(EntityTypeBuilder<SaleTransaction> builder)
        {
            builder.ToTable("SaleTransactions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId);
            builder.Property(x => x.CustomerId);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.IsVoided);
            builder.Property(x => x.SerialNumber);
            builder.Property(x => x.Type);
        }
    }
}
