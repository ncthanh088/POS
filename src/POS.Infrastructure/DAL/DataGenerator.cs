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
            if (!_dbContext.Categories.Any())
            {
                // Add data for Categories table
                var categories = new Category[] {
                    new Category(1001,"Coffee", "Various types of coffee drinks", string.Empty),
                    new Category(1002,"Breakfast", "Breakfast items such as sandwiches, pastries, etc.", string.Empty),
                    new Category(1003,"Tea", "Different flavors of tea drinks", string.Empty),
                    new Category(1005,"Lunch", "Various types of water" , string.Empty),
                    new Category(1006,"Dinner", "Dinner items such as pastries, etc.", string.Empty),
                    new Category(1004,"Beverages", "Various beverages including coffee, tea, and soft drinks", string.Empty),
                    new Category(1007,"Milk", "Different flavors of milk drinks", string.Empty),
                    new Category(1008,"Orders", "Various beverages including coffee, tea, and soft drinks", string.Empty)
                };
                _dbContext.Categories.AddRange(categories);
                await _dbContext.SaveChangesAsync();
            }

            if (!_dbContext.Products.Any())
            {
                // Add data for Products table
                var products = new Product[] {
                    new Product(new Guid("a99538e3-f198-4901-98ea-2ece0c5042c9") ,"Espresso", "Strong coffee brewed by forcing hot water under pressure through finely-ground coffee beans.",Domain.Enums.ProductType.Other , "Coffee Company", 2.5m, 100, "espresso.jpg", 1001),
                    new Product(new Guid("24606e8c-f457-4ab8-90ae-6b1c2155b634"),"Cappuccino", "Coffee drink that consists of espresso, hot milk, and steamed milk foam.", Domain.Enums.ProductType.Housing, "Coffee Company", 3.5m, 80, "cappuccino.jpg", 1001),
                    new Product(new Guid("f59222ab-6fc8-48f9-bd11-97cc878e3576"),"Breakfast Sandwich", "Sandwich typically consisting of one or more cooked eggs with cheese, meat, or vegetables, served on a bun or roll.", Domain.Enums.ProductType.Other, "Café", 4m, 30, "breakfast_sandwich.jpg", 1002),
                    new Product(new Guid("33610723-800e-4e15-b235-5def1a2600f7"),"Croissant", "Buttery, flaky pastry that is often eaten for breakfast.", Domain.Enums.ProductType.Housing, "Bakery", 2m, 50, "croissant.jpg", 1002),
                    new Product(new Guid("92547551-a989-4e72-b2ce-ab1a7795c3d3"),"Bottled Water", "Plain bottled water.", Domain.Enums.ProductType.Other, "Water Company", 1.5m, 200, "bottled_water.jpg", 1004),
                    new Product(new Guid("5b88dde4-5340-401e-b744-c7c155599575"),"Sparkling Water", "Carbonated bottled water.", Domain.Enums.ProductType.Other, "Water Company", 2m, 150, "sparkling_water.jpg", 1004),
                    new Product(new Guid("3d2ab0aa-4ef2-4ef8-972e-1b79f96dec7d"),"Classic Milk Tea", "Traditional milk tea with black tea and milk.", Domain.Enums.ProductType.Kitchen, "Tea Shop", 3.5m, 100, "milk_tea.jpg", 1003),
                    new Product(new Guid("dc90ff6a-66c9-44a4-a9f8-659a1cd47830"),"Matcha Latte", "Green tea latte made with matcha powder and steamed milk.", Domain.Enums.ProductType.Kitchen, "Tea Shop", 4m, 80, "matcha_latte.jpg", 1003)};

                _dbContext.Products.AddRange(products);
                await _dbContext.SaveChangesAsync();
            }

            // Dummy data for Customers table.
            if (!_dbContext.Customers.Any())
            {
                var faker = new Faker();

                var customers = new Faker<Customer>()
                    .RuleFor(c => c.CustomerId, f => Guid.NewGuid())
                    .RuleFor(c => c.FirstName, f => f.Person.FirstName)
                    .RuleFor(c => c.LastName, f => f.Person.LastName)
                    .RuleFor(c => c.Phone, f => f.Person.Phone)
                    .RuleFor(c => c.Address, f => f.Address.FullAddress())
                    .Generate(10);

                _dbContext.Customers.AddRange(customers);
                await _dbContext.SaveChangesAsync();
            }

            // Dummy data for Discounts table.
            if (!_dbContext.Discounts.Any())
            {
                var discounts = new List<Discount>  {
                    new Discount {
                        Id = Guid.NewGuid(),
                        Name = "10% Off",
                        Description = "Get 10% off on all items",
                        Type = "percent",
                        Amount = 10,
                        EffectiveFrom = DateTime.UtcNow.Date,
                        EffectiveTo = DateTime.UtcNow.Date.AddDays(30)
                    },
                    new Discount
                    {
                        Id = Guid.NewGuid(),
                        Name = "50% Off",
                        Description = "Get 50% off on selected items",
                        Type = "percent",
                        Amount = 50,
                        EffectiveFrom = DateTime.UtcNow.Date,
                        EffectiveTo = DateTime.UtcNow.Date.AddDays(15)
                    },
                    new Discount
                    {
                        Id = Guid.NewGuid(),
                        Name = "$5 Off",
                        Description = "Get $5 off on your purchase",
                        Type = "amount",
                        Amount = 5,
                        EffectiveFrom = DateTime.UtcNow.Date,
                        EffectiveTo = DateTime.UtcNow.Date.AddDays(30)
                    },
                    new Discount
                    {
                        Id = Guid.NewGuid(),
                        Name = "$10 Off",
                        Description = "Get $10 off on orders over $50",
                        Type = "amount",
                        Amount = 10,
                        EffectiveFrom = DateTime.UtcNow.Date,
                        EffectiveTo = DateTime.UtcNow.Date.AddDays(30)
                    }
                };

                _dbContext.Discounts.AddRange(discounts);
                await _dbContext.SaveChangesAsync();
            }

            if (!_dbContext.Taxes.Any())
            {
                var taxes = new List<Tax>
                {
                    new Tax
                    {
                        Id = Guid.NewGuid(),
                        Name = "VAT",
                        Description = "Value Added Tax",
                        Percentage = 10, // 10%
                        Status = "Active",
                        StartDate = DateTime.UtcNow.Date,
                        EndDate = DateTime.UtcNow.Date.AddDays(365) // Valid for 1 year
                    },
                    new Tax
                    {
                        Id = Guid.NewGuid(),
                        Name = "GST",
                        Description = "Goods and Services Tax",
                        Percentage = 5, // 5%
                        Status = "Active",
                        StartDate = DateTime.UtcNow.Date,
                        EndDate = DateTime.UtcNow.Date.AddDays(365) // Valid for 1 year
                    },
                    new Tax
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sales Tax",
                        Description = "Sales Tax",
                        Percentage = 8, // 8%
                        Status = "Active",
                        StartDate = DateTime.UtcNow.Date,
                        EndDate = DateTime.UtcNow.Date.AddDays(365) // Valid for 1 year
                    }
                };
                _dbContext.Taxes.AddRange(taxes);
                await _dbContext.SaveChangesAsync();
            }

            if (!_dbContext.Users.Any())
            {
                var users = new List<User>
                {
                    new User(
                        Guid.NewGuid(),
                        "john.doe@example.com",
                        "johndoe",
                        "password1",
                        "John Doe",
                        "User",
                        DateTime.UtcNow
                    ),
                    new User(
                        Guid.NewGuid(),
                        "marry.lane@example.com",
                        "merrylane",
                        "password2",
                        "Marry Lane",
                        "User",
                        DateTime.UtcNow
                    ),
                    new User(
                        Guid.NewGuid(),
                        "admin@example.com",
                        "admin",
                        "adminpassword",
                        "Administrator",
                        "Admin",
                        DateTime.UtcNow
                    )
                };

                _dbContext.Users.AddRange(users);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
