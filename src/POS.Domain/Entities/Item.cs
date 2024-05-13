using POS.Domain.Enums;

namespace POS.Domain.Entities;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ItemType Type { get; set; } = ItemType.Other;
    public string Vendor { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryID { get; set; }
    public bool IsActived { get; set; } = true;
    public IEnumerable<SaleLineItem> Items { get; set; }
}
