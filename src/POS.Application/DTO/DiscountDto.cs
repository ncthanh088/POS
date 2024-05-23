using POS.Domain.Entities;
using System.Linq.Expressions;

namespace POS.Application.DTO;

public class DiscountDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public bool InclusiveOfTax { get; set; }
    public bool IsRequiredMember { get; set; }

    public static Expression<Func<Discount, DiscountDto>> Expression
    {
        get
        {
            return discount => new DiscountDto
            {
                Id = discount.Id,
                Name = discount.Name,
                Type = discount.Type,
                Amount = discount.Amount,
                IsRequiredMember = discount.IsRequiredMember,
                InclusiveOfTax = discount.InclusiveOfTax
            };
        }
    }

    public static DiscountDto Parse(Discount discount)
    {
        if (discount == null)
            return null;
        return Expression.Compile().Invoke(discount);
    }
}
