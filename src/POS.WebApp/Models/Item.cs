namespace POS.WebApp.Models;

public class Item
{
    public Guid Id { get; set; }
    public Guid CartId { get; set; }
    public string ProductId { get; set; }
    public Product Product { get; set; }
    public string ProductName { get; set; }
    public string ImageUrl { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
}
