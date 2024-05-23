using System.Linq.Expressions;
using POS.Domain.Entities;

namespace POS.Application.DTO;

public class TaxDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Percentage { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public static Expression<Func<Tax, TaxDto>> Expression
    {
        get
        {
            return tax => new TaxDto
            {
                Id = tax.Id,
                Name = tax.Name,
                Description = tax.Description,
                Amount = tax.Percentage,
            };
        }
    }

    public static TaxDto Parse(Tax tax)
    {
        if (tax == null)
            return null;
        return Expression.Compile().Invoke(tax);
    }
}
