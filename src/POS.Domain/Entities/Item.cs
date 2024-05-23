using POS.Domain.Enums;

namespace POS.Domain.Entities;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool RequiresMember { get; set; }
    public string Description { get; set; }
    public ItemType Type { get; set; } = ItemType.Sale;
    public string Vendor { get; set; }
    public decimal Price { get; set; } // Included Tax amount.
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public bool IsActived { get; set; } = true;
    public int TaxId { get; set; }
    public Tax Tax { get; set; }
}
