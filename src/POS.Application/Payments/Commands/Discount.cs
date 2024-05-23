using POS.Domain.Enums;

namespace POS.Application.Payments.Commands;

public class Discount
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DiscountType Type { get; set; }
    public decimal Amount { get; set; }
    public bool InclusiveOfTax { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
}
