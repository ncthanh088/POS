using POS.Domain.Enums;

namespace POS.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public ProductType Type { get; set; } = ProductType.Other; // Default value
    public string Vendor { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }

    public Product(Guid id, string name, string description, ProductType type,
        string vendor, decimal price, int quantity, string imageUrl, int categoryId)
    {
        Id = id;
        Name = name;
        Description = description;
        Type = type;
        Vendor = vendor;
        Price = price;
        Quantity = quantity;
        ImageUrl = imageUrl;
        CategoryId = categoryId;
    }
}
