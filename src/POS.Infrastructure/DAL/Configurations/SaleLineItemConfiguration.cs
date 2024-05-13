using POS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace POS.Infrastructure.DAL.Configurations
{
    public class SaleLineItemConfiguration : IEntityTypeConfiguration<SaleLineItem>
    {
        public void Configure(EntityTypeBuilder<SaleLineItem> builder)
        {
            builder.ToTable("SaleLineItems");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ItemId);

            builder.Property(x => x.DiscountId);
            builder.Property(x => x.IsMemberBenefit);
            builder.Property(x => x.IsMemberBenefit);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.ActualUnitPrice);
            builder.Property(x => x.ExtendedPrice);
            builder.Property(x => x.TotalPrice);
        }
    }
}
