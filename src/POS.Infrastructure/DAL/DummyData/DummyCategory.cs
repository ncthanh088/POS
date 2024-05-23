using POS.Domain.Entities;

namespace POS.Infrastructure.DAL.DummyData;

public class DummyCategory
{
    public static List<Category> _categories = new List<Category>()
    {
            new Category
                {
                    Id = 1001,
                    Name = "Coffee",
                    Description = "All types of coffee beverages",
                    Icon = "category_coffee.svg",
                    Color = "#D0DEDB",
                },
                new Category
                {
                    Id = 1002,
                    Name = "Breakfast",
                    Description = "Delicious breakfast items",
                    Icon = "category_luncher.svg",
                    Color = "#E4CDEC",
                },
                new Category
                {
                    Id = 1003,
                    Name = "Dinner",
                    Description = "Hearty dinner meals",
                    Icon = "category_coffee.svg",
                    Color = "#E4DADE",
                },
                new Category
                {
                    Id = 1004,
                    Name = "Desserts",
                    Description = "Sweet and delightful desserts",
                    Icon = "category_luncher.svg",
                    Color = "#F8C0D8",
                },
                new Category
                {
                    Id = 1005,
                    Name = "Beverages",
                    Description = "Refreshing beverages",
                    Icon = "category_coffee.svg",
                    Color = "#E4CDEC",
                },
                new Category
                {
                    Id = 1006,
                    Name = "Sandwiches",
                    Description = "Tasty sandwiches",
                    Icon = "category_drink.svg",
                    Color = "#D0DEDB",
                },
                new Category
                {
                    Id = 1007,
                    Name = "Salads",
                    Description = "Healthy and fresh salads",
                    Icon = "category_luncher.svg",
                    Color = "#EFC7D0",
                }
    };
}
