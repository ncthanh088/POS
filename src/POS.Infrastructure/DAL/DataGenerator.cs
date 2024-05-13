using Bogus;
using POS.Application.Data;
using POS.Domain.Entities;

namespace POS.Infrastructure.DAL
{
    public class DataGenerator : IDataGenerator
    {
        private readonly POSDbContext _dbContext;

        public DataGenerator(POSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Initialize()
        {
            //     if (!_dbContext.Categories.Any())
            //     {
            //         // Add data for Categories table
            //         var categories = new Category[] {
            //             new Category(1001,"Coffee", "Various types of coffee drinks", "category_coffee.svg", "#D0DEDB"),
            //             new Category(1002,"Breakfast", "Breakfast items such as sandwiches, pastries, etc.", "category_luncher.svg", "#E4CDEC"),
            //             new Category(1003,"Tea", "Different flavors of tea drinks", "category_luncher.svg", "#EFC7D0"),
            //             new Category(1005,"Lunch", "Various types of water" , "category_coffee.svg", "#E4DADE"),
            //             new Category(1006,"Dinner", "Dinner items such as pastries, etc.", "category_drink.svg", "#F8C0D8"),
            //             new Category(1004,"Beverages", "Various beverages including coffee, tea, and soft drinks", "category_luncher.svg", "#E4CDEC"),
            //             new Category(1007,"Milk", "Different flavors of milk drinks", "category_drink.svg", "#D0DEDB"),
            //             new Category(1008,"Orders", "Various beverages including coffee, tea, and soft drinks", "category_drink.svg", "#EFC7D0")
            //         };
            //         _dbContext.Categories.AddRange(categories);
            //         await _dbContext.SaveChangesAsync();
            //     }

            //     if (!_dbContext.Items.Any())
            //     {
            //         // Add data for Products table
            //         var products = new Item[] {
            //             new Item(new Guid("a99538e3-f198-4901-98ea-2ece0c5042c9") ,"Espresso", "Strong coffee brewed by forcing hot water under pressure through finely-ground coffee beans.",Domain.Enums.ProductType.Other , "Coffee Company", 2.5m, 100, "espresso.jpg", 1001),
            //             new Item(new Guid("24606e8c-f457-4ab8-90ae-6b1c2155b634"),"Cappuccino", "Coffee drink that consists of espresso, hot milk, and steamed milk foam.", Domain.Enums.ProductType.Housing, "Coffee Company", 3.5m, 80, "cappuccino.jpg", 1001),
            //             new Item(new Guid("f59222ab-6fc8-48f9-bd11-97cc878e3576"),"Sandwich", "Sandwich typically consisting of one or more cooked eggs with cheese, meat, or vegetables, served on a bun or roll.", Domain.Enums.ProductType.Other, "Café", 4m, 30, "breakfast_sandwich.jpg", 1002),
            //             new Item(new Guid("33610723-800e-4e15-b235-5def1a2600f7"),"Croissant", "Buttery, flaky pastry that is often eaten for breakfast.", Domain.Enums.ProductType.Housing, "Bakery", 2m, 50, "croissant.jpg", 1002),
            //             new Item(new Guid("92547551-a989-4e72-b2ce-ab1a7795c3d3"),"Bottled Water", "Plain bottled water.", Domain.Enums.ProductType.Other, "Water Company", 1.5m, 200, "bottled_water.jpg", 1004),
            //             new Item(new Guid("5b88dde4-5340-401e-b744-c7c155599575"),"Sparkling Water", "Carbonated bottled water.", Domain.Enums.ProductType.Other, "Water Company", 2m, 150, "sparkling_water.jpg", 1004),
            //             new Item(new Guid("3d2ab0aa-4ef2-4ef8-972e-1b79f96dec7d"),"Classic Milk", "Traditional milk tea with black tea and milk.", Domain.Enums.ProductType.Kitchen, "Tea Shop", 3.5m, 100, "milk_tea.jpg", 1003),
            //             new Item(new Guid("dc90ff6a-66c9-44a4-a9f8-659a1cd47830"),"Matcha Latte", "Green tea latte made with matcha powder and steamed milk.", Domain.Enums.ProductType.Kitchen, "Tea Shop", 4m, 80, "matcha_latte.jpg", 1003),
            //             new Item(new Guid("3a80d607-94d2-47ae-b069-77368aef89c7"), "Latte", "Coffee drink made with espresso and steamed milk.", Domain.Enums.ProductType.Other , "Coffee Company", 3m, 90, "latte.jpg", 1001),
            //             new Item(new Guid("f25c7a55-d3e7-4d6c-a1aa-b5292a91e674"), "Iced Coffee", "Chilled coffee beverage.", Domain.Enums.ProductType.Other , "Coffee Company", 4.5m, 120, "iced_coffee.jpg", 1001),
            //             new Item(new Guid("df8b3ef2-0e7d-4146-bcb3-0a6ed0b64b0d"), "Bagel", "Ring-shaped bread roll.", Domain.Enums.ProductType.Housing, "Bakery", 1.8m, 60, "bagel.jpg", 1002),
            //             new Item(new Guid("aa472598-464e-4656-b1a9-3b9432b2d759"), "Donut", "Fried dough confection.", Domain.Enums.ProductType.Housing, "Bakery", 2.2m, 40, "donut.jpg", 1006),
            //             new Item(new Guid("0b67db63-1d4d-49c1-805a-9ee3de94bf50"), "Juice", "Liquid extract of fruit or vegetables.", Domain.Enums.ProductType.Other, "Juice Bar", 3m, 150, "juice.jpg", 1004),
            //             new Item(new Guid("e106b9aa-9e9f-4dc0-8a49-b25466313c17"), "Smoothie", "Thick, cold beverage made from blended raw fruit or vegetables.", Domain.Enums.ProductType.Other, "Smoothie Bar", 4m, 100, "smoothie.jpg", 1004),
            //             new Item(new Guid("7b25832b-d9d7-4f86-9f8d-fc03a75d4bb4"), "Green Tea", "Tea made solely with the leaves of Camellia sinensis that have undergone minimal oxidation.", Domain.Enums.ProductType.Kitchen, "Tea Shop", 2.5m, 120, "green_tea.jpg", 1003),
            //             new Item(new Guid("e1b8b29d-fec8-49c1-98a2-5d168a05a26a"), "Black Tea", "Tea that is more oxidized than white, green, and oolong teas.", Domain.Enums.ProductType.Kitchen, "Tea Shop", 2m, 110, "black_tea.jpg", 1003),
            //             new Item(new Guid("6e945f1e-2a2e-4a29-98d6-6e9173e7d367"), "Iced Tea", "Chilled tea beverage.", Domain.Enums.ProductType.Kitchen, "Tea Shop", 3m, 120, "iced_tea.jpg", 1003),
            //             new Item(new Guid("9fdac8df-8a0a-4bcf-b8ec-5a6e45ff7f10"), "Latte Macchiato", "Coffee drink made with espresso and steamed milk with a small amount of milk foam.", Domain.Enums.ProductType.Other , "Coffee Company", 3.8m, 80, "latte_macchiato.jpg", 1008),
            //             new Item(new Guid("7148375b-7808-4043-9485-5837580de7a7"), "Chocolate", "Croissant filled with chocolate.", Domain.Enums.ProductType.Housing, "Bakery", 2.3m, 40, "chocolate_croissant.jpg", 1002),
            //             new Item(new Guid("ff4d6494-09b8-44d1-b019-e48ac9d0df10"), "Fruit Juice", "Juice made from fruits.", Domain.Enums.ProductType.Other, "Juice Bar", 3.5m, 150, "fruit_juice.jpg", 1004),
            //             new Item(new Guid("aa44d38e-2a16-4207-b16e-9a78a5ac0f1a"), "Iced Latte", "Chilled coffee drink made with espresso and cold milk.", Domain.Enums.ProductType.Other , "Coffee Company", 4m, 100, "iced_latte.jpg", 1007),
            //             new Item(new Guid("50e0632d-c539-4c26-8045-5a27417f7cd3"), "Baguette", "Long, narrow loaf of French bread.", Domain.Enums.ProductType.Housing, "Bakery", 2.5m, 60, "baguette.jpg", 1002),
            //             new Item(new Guid("cf7c4cc3-8031-466a-8560-1b58cc2708c0"), "Bubble Tea", "Tea-based drink originating in Taiwan, often containing chewy tapioca balls.", Domain.Enums.ProductType.Kitchen, "Tea Shop", 4.5m, 90, "bubble_tea.jpg", 1007),
            //             new Item(new Guid("bbce052e-fa0d-4da1-a8f1-dc5f90f6b839"), "Vanilla Latte", "Coffee drink made with espresso, steamed milk, and vanilla syrup.", Domain.Enums.ProductType.Other , "Coffee Company", 3.5m, 70, "vanilla_latte.jpg", 1008),
            //             new Item(new Guid("aed9e78d-6b5c-44e7-a2dc-8f45da780d1a"), "Blueberry Muffin", "Muffin made with blueberries.", Domain.Enums.ProductType.Housing, "Bakery", 2.2m, 50, "blueberry_muffin.jpg", 1002),
            //             new Item(new Guid("4226b294-960d-46d0-9a44-14126c328f48"), "Green Smoothie", "Smoothie made with green vegetables and fruits.", Domain.Enums.ProductType.Other, "Smoothie Bar", 4.2m, 80, "green_smoothie.jpg", 1004)
            //             };

            //         _dbContext.Items.AddRange(products);
            //         await _dbContext.SaveChangesAsync();
            //     }

            //     // Dummy data for Customers table.
            //     if (!_dbContext.Customers.Any())
            //     {
            //         var faker = new Faker();

            //         var customers = new Faker<Customer>()
            //             .RuleFor(c => c.CustomerId, f => Guid.NewGuid())
            //             .RuleFor(c => c.FirstName, f => f.Person.FirstName)
            //             .RuleFor(c => c.LastName, f => f.Person.LastName)
            //             .RuleFor(c => c.Phone, f => f.Person.Phone)
            //             .RuleFor(c => c.Address, f => f.Address.FullAddress())
            //             .Generate(10);

            //         _dbContext.Customers.AddRange(customers);
            //         await _dbContext.SaveChangesAsync();
            //     }

            //     // Dummy data for Discounts table.
            //     if (!_dbContext.Discounts.Any())
            //     {
            //         var discounts = new List<Discount>  {
            //             new Discount {
            //                 Id = Guid.NewGuid(),
            //                 Name = "10% Off",
            //                 Description = "Get 10% off on all items",
            //                 Type = "percent",
            //                 Amount = 10,
            //                 EffectiveFrom = DateTime.UtcNow.Date,
            //                 EffectiveTo = DateTime.UtcNow.Date.AddDays(30)
            //             },
            //             new Discount
            //             {
            //                 Id = Guid.NewGuid(),
            //                 Name = "50% Off",
            //                 Description = "Get 50% off on selected items",
            //                 Type = "percent",
            //                 Amount = 50,
            //                 EffectiveFrom = DateTime.UtcNow.Date,
            //                 EffectiveTo = DateTime.UtcNow.Date.AddDays(15)
            //             },
            //             new Discount
            //             {
            //                 Id = Guid.NewGuid(),
            //                 Name = "$5 Off",
            //                 Description = "Get $5 off on your purchase",
            //                 Type = "amount",
            //                 Amount = 5,
            //                 EffectiveFrom = DateTime.UtcNow.Date,
            //                 EffectiveTo = DateTime.UtcNow.Date.AddDays(30)
            //             },
            //             new Discount
            //             {
            //                 Id = Guid.NewGuid(),
            //                 Name = "$10 Off",
            //                 Description = "Get $10 off on orders over $50",
            //                 Type = "amount",
            //                 Amount = 10,
            //                 EffectiveFrom = DateTime.UtcNow.Date,
            //                 EffectiveTo = DateTime.UtcNow.Date.AddDays(30)
            //             }
            //         };

            //         _dbContext.Discounts.AddRange(discounts);
            //         await _dbContext.SaveChangesAsync();
            //     }

            //     if (!_dbContext.Taxes.Any())
            //     {
            //         var taxes = new List<Tax>
            //         {
            //             new Tax
            //             {
            //                 Id = Guid.NewGuid(),
            //                 Name = "VAT",
            //                 Description = "Value Added Tax",
            //                 Percentage = 10, // 10%
            //                 Status = "Active",
            //                 StartDate = DateTime.UtcNow.Date,
            //                 EndDate = DateTime.UtcNow.Date.AddDays(365) // Valid for 1 year
            //             },
            //             new Tax
            //             {
            //                 Id = Guid.NewGuid(),
            //                 Name = "GST",
            //                 Description = "Goods and Services Tax",
            //                 Percentage = 5, // 5%
            //                 Status = "Active",
            //                 StartDate = DateTime.UtcNow.Date,
            //                 EndDate = DateTime.UtcNow.Date.AddDays(365) // Valid for 1 year
            //             },
            //             new Tax
            //             {
            //                 Id = Guid.NewGuid(),
            //                 Name = "Sales Tax",
            //                 Description = "Sales Tax",
            //                 Percentage = 8, // 8%
            //                 Status = "Active",
            //                 StartDate = DateTime.UtcNow.Date,
            //                 EndDate = DateTime.UtcNow.Date.AddDays(365) // Valid for 1 year
            //             }
            //         };
            //         _dbContext.Taxes.AddRange(taxes);
            //         await _dbContext.SaveChangesAsync();
            //     }

            //     if (!_dbContext.Users.Any())
            //     {
            //         var users = new List<User>
            //         {
            //             new User(
            //                 Guid.NewGuid(),
            //                 "john.doe@example.com",
            //                 "johndoe",
            //                 "password1",
            //                 "John Doe",
            //                 "User",
            //                 DateTime.UtcNow
            //             ),
            //             new User(
            //                 Guid.NewGuid(),
            //                 "marry.lane@example.com",
            //                 "merrylane",
            //                 "password2",
            //                 "Marry Lane",
            //                 "User",
            //                 DateTime.UtcNow
            //             ),
            //             new User(
            //                 Guid.NewGuid(),
            //                 "admin@example.com",
            //                 "admin",
            //                 "adminpassword",
            //                 "Administrator",
            //                 "Admin",
            //                 DateTime.UtcNow
            //             )
            //         };

            //         _dbContext.Users.AddRange(users);
            //         await _dbContext.SaveChangesAsync();
            //     }
        }
    }
}
