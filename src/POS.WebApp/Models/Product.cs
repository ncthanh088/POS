namespace POS.WebApp;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public int Type { get; set; } = 0;
    public string Vendor { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public string ImageUrl { get; set; } = string.Empty;
}
