namespace POS.Domain.Entities;

public class Item
{
    public Guid Id { get; set; }
    public Guid CartId { get; set; }
    public Cart Cart { get; set; }
    public Guid ProductId { get; private set; }
    public Product Product { get; private set; }
    public string ProductName { get; private set; }
    public string ImageUrl { get; set; }
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public decimal TotalPrice => Quantity * UnitPrice;

    protected Item()
    {
    }

    public Item(Product product, int quantity)
    {
        ProductId = product.Id;
        ProductName = product.Name;
        UnitPrice = product.Price;
        Quantity = quantity;
    }

    public Item(Guid productId, string productName,
        string imageUrl, int quantity, decimal unitPrice)
    {
        ProductId = productId;
        ProductName = productName;
        ImageUrl = imageUrl;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public void IncreaseQuantity(int quantity)
    {
        Quantity += quantity;
    }

    public void Update(Product product)
    {
        ProductName = product.Name;
        UnitPrice = product.Price;
    }
}
