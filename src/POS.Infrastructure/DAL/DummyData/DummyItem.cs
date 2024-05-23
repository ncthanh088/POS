using POS.Domain.Entities;
using POS.Domain.Enums;

namespace POS.Infrastructure.DAL.DummyData;

public class DummyItem
{
    public static List<Item> _items = new List<Item>() {
        new Item
        {
            Name = "Pancakes",
            Description = "Fluffy pancakes with syrup",
            Type = ItemType.Sale,
            Vendor = "BreakfastCorner",
            Price = 5.50m,
            Quantity = 50,
            ImageUrl = "https://example.com/images/pancakes.jpg",
            CategoryId = 1004,
            TaxId = 1001,
            IsActived = true
        },
        new Item
        {
            Name = "Waffles",
            Description = "Crispy waffles with toppings",
            Type = ItemType.Sale,
            Vendor = "BreakfastCorner",
            Price = 6.00m,
            Quantity = 50,
            ImageUrl = "https://example.com/images/waffles.jpg",
            CategoryId = 1004,
            TaxId = 1001,
            IsActived = true
        },
        new Item
        {
            Name = "Scrambled Eggs",
            Description = "Soft and creamy scrambled eggs",
            Type = ItemType.Sale,
            Vendor = "BreakfastCorner",
            Price = 3.00m,
            Quantity = 100,
            ImageUrl = "https://example.com/images/scrambledeggs.jpg",
            CategoryId = 1003,
            TaxId = 1002,
            IsActived = true
        },
        new Item
        {
            Name = "French Toast",
            Description = "Classic French toast with cinnamon",
            Type = ItemType.Sale,
            Vendor = "BreakfastCorner",
            Price = 5.00m,
            Quantity = 50,
            ImageUrl = "https://example.com/images/frenchtoast.jpg",
            CategoryId = 1002,
            TaxId = 1002,
            IsActived = true
        },
        new Item
        {
            Name = "Omelette",
            Description = "Omelette with vegetables and cheese",
            Type = ItemType.Sale,
            Vendor = "BreakfastCorner",
            Price = 4.50m,
            Quantity = 100,
            ImageUrl = "https://example.com/images/omelette.jpg",
            CategoryId = 1002,
            TaxId = 1002,
            IsActived = true
        },
        new Item
        {
            Name = "Bagel with Cream Cheese",
            Description = "Fresh bagel with cream cheese",
            Type = ItemType.Sale,
            Vendor = "BreakfastCorner",
            Price = 2.50m,
            Quantity = 100,
            ImageUrl = "https://example.com/images/bagel.jpg",
            CategoryId = 1002,
            TaxId = 1002,
            IsActived = true
        },
        new Item
        {
            Name = "Breakfast Burrito",
            Description = "Burrito with eggs, cheese, and sausage",
            Type = ItemType.Sale,
            Vendor = "BreakfastCorner",
            Price = 6.50m,
            Quantity = 50,
            ImageUrl = "https://example.com/images/breakfastburrito.jpg",
            CategoryId = 1003,
            TaxId = 1002,
            IsActived = true
        },
        new Item
        {
            Name = "Smoothie Bowl",
            Description = "Healthy smoothie bowl with fruits",
            Type = ItemType.Sale,
            Vendor = "BreakfastCorner",
            Price = 7.00m,
            Quantity = 50,
            ImageUrl = "https://example.com/images/smoothiebowl.jpg",
            CategoryId = 1002,
            TaxId = 1002,
            IsActived = true
        },
        new Item
        {
            Name = "Yogurt Parfait",
            Description = "Yogurt with granola and berries",
            Type = ItemType.Sale,
            Vendor = "BreakfastCorner",
            Price = 4.00m,
            Quantity = 50,
            ImageUrl = "https://example.com/images/yogurtparfait.jpg",
            CategoryId = 1002,
            TaxId = 1002,
            IsActived = true
        },
        new Item
        {
            Name = "Avocado Toast",
            Description = "Toast with mashed avocado and spices",
            Type = ItemType.Sale,
            Vendor = "BreakfastCorner",
            Price = 5.50m,
            Quantity = 100,
            ImageUrl = "https://example.com/images/avocadotoast.jpg",
            CategoryId = 1001,
            TaxId = 1002,
            IsActived = true
        }
    };
}
