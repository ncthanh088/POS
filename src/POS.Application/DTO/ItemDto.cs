using POS.Domain.Enums;
using System.Linq.Expressions;

namespace POS.Application.DTO;

public class ItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool TaxOnGrossAmount { get; set; }
    public bool RequiresMember { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public ItemType Type { get; set; }
    public string Vendor { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int TaxId { get; set; }
    public TaxDto Tax { get; set; }
    public IEnumerable<DiscountDto> Discounts { get; private set; }


    public static Expression<Func<Domain.Entities.Item, ItemDto>> Expression
    {
        get
        {
            return item => new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                ImageUrl = item.ImageUrl,
                Price = item.Price,
                Quantity = item.Quantity,
                Type = item.Type,
                Tax = new TaxDto()
                {
                    Id = item.TaxId,
                    Name = item.Tax == null ? string.Empty : item.Tax.Name,
                    Description = item.Tax == null ? string.Empty : item.Tax.Description,
                    Amount = item.Tax == null ? 0M : item.Tax.Percentage,
                },
            };
        }
    }

    public static ItemDto Parse(Domain.Entities.Item item)
    {
        if (item == null)
        {
            return null;
        }
        return Expression.Compile().Invoke(item);
    }
}
