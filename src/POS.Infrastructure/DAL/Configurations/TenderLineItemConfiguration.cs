using POS.Domain.Enums;
using POS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace POS.Infrastructure.DAL.Configurations
{
    public class TenderLineItemConfiguration : IEntityTypeConfiguration<TenderLineItem>
    {
        public void Configure(EntityTypeBuilder<TenderLineItem> builder)
        {
            builder.ToTable("TenderLineItems");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
        }
    }
}
