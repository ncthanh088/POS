using POS.Domain.Enums;
using POS.Domain.ValueObjects;

namespace POS.Domain.Entities;

public class Product
{
    public ProductId Id { get; private set; }
    public ProductName Name { get; private set; }
    public ProductDescription Description { get; private set; }
    public ProductType Type { get; set; } = ProductType.Other; // Default value
    public Vendor Vendor { get; private set; }
    public ProductPrice Price { get; private set; }
    public ProductQuantity Quantity { get; private set; }
    public string ImageUrl { get; set; }

    public Product(ProductId id, ProductName name, ProductDescription description, ProductType type,
        Vendor vendor, ProductPrice price, ProductQuantity quantity, string imageUrl)
    {
        Id = id;
        Name = name;
        Description = description;
        Type = type;
        Vendor = vendor;
        Price = price;
        Quantity = quantity;
        ImageUrl = imageUrl;
    }
}
