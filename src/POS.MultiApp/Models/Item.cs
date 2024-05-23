namespace POS.MultiApp.Models;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Type { get; set; } = 0;
    public string Vendor { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
    public bool TaxOnGrossAmount { get; set; }
    public bool RequiresMember { get; set; }
    public int TaxId { get; set; }
    public Tax Tax { get; set; }
    public decimal TotalPrice => Price * Quantity;
}
