using POS.Domain.Enums;
using POS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace POS.Infrastructure.DAL.Configurations
{
    public class TaxLineItemConfiguration : IEntityTypeConfiguration<TaxLineItem>
    {
        public void Configure(EntityTypeBuilder<TaxLineItem> builder)
        {
            builder.ToTable("TaxLineItems");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
        }
    }
}
