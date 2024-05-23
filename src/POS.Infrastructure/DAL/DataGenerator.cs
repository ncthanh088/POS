using Bogus;
using POS.Application.Data;
using POS.Application.Security;
using POS.Domain.Entities;
using POS.Infrastructure.DAL.DummyData;

namespace POS.Infrastructure.DAL;

public class DataGenerator : IDataGenerator
{
    private readonly POSDbContext _dbContext;
    private readonly IPasswordManager _passwordManager;


    public DataGenerator(POSDbContext dbContext, IPasswordManager passwordManager)
    {
        _dbContext = dbContext;
        _passwordManager = passwordManager;
    }

    public async Task Initialize()
    {
        if (!_dbContext.Taxes.Any())
        {
            var taxes = new List<Tax>
                {
                    new Tax
                    {
                        Id = 1001,
                        Name = "VAT",
                        Description = "Value Added Tax",
                        Percentage = 10, // 10%
                        Status = "Active",
                        StartDate = DateTime.UtcNow.Date,
                        EndDate = DateTime.UtcNow.Date.AddDays(365) // Valid for 1 year
                    },
                    new Tax
                    {
                        Id = 1002,
                        Name = "GST",
                        Description = "Goods and Services Tax",
                        Percentage = 5, // 5%
                        Status = "Active",
                        StartDate = DateTime.UtcNow.Date,
                        EndDate = DateTime.UtcNow.Date.AddDays(365) // Valid for 1 year
                    },
                    new Tax
                    {
                        Id = 1003,
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

        if (!_dbContext.Categories.Any())
        {
            // Add data for Categories table
            var categories = DummyCategory._categories;
            _dbContext.Categories.AddRange(categories);
            await _dbContext.SaveChangesAsync();
        }

        if (!_dbContext.Items.Any())
        {
            // Add data for Products table
            var items = DummyItem._items;

            _dbContext.Items.AddRange(items);
            await _dbContext.SaveChangesAsync();
        }

        // Dummy data for Customers table.
        if (!_dbContext.Customers.Any())
        {
            var faker = new Faker();

            var customers = new Faker<Customer>()
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
                        Name = "10% Off",
                        Description = "Get 10% off on all items",
                        Type = "percent",
                        Amount = 10,
                        EffectiveFrom = DateTime.UtcNow.Date,
                        EffectiveTo = DateTime.UtcNow.Date.AddDays(30)
                    },
                    new Discount
                    {
                        Name = "50% Off",
                        Description = "Get 50% off on selected items",
                        Type = "percent",
                        Amount = 50,
                        EffectiveFrom = DateTime.UtcNow.Date,
                        EffectiveTo = DateTime.UtcNow.Date.AddDays(15)
                    },
                    new Discount
                    {
                        Name = "$5 Off",
                        Description = "Get $5 off on your purchase",
                        Type = "amount",
                        Amount = 5,
                        EffectiveFrom = DateTime.UtcNow.Date,
                        EffectiveTo = DateTime.UtcNow.Date.AddDays(30)
                    },
                    new Discount
                    {
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

        if (!_dbContext.Users.Any())
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "john.doe@example.com",
                    Username = "john.doe",
                    Password = _passwordManager.Secure("Password123!"),
                    FullName = "John Doe",
                    Role = "Admin",
                    CreatedAt = DateTime.UtcNow.AddDays(-100)
                },
                new User
                {
                    Id = 2,
                    Email = "jane.smith@example.com",
                    Username = "jane.smith",
                    Password = _passwordManager.Secure("SecurePass456!"),
                    FullName = "Jane Smith",
                    Role = "User",
                    CreatedAt = DateTime.UtcNow.AddDays(-50)
                },
                new User
                {
                    Id = 3,
                    Email = "alice.johnson@example.com",
                    Username = "alice.johnson",
                    Password = _passwordManager.Secure("MyPass789!"),
                    FullName = "Alice Johnson",
                    Role = "Manager",
                    CreatedAt = DateTime.UtcNow.AddDays(-200)
                },
                new User
                {
                    Id = 4,
                    Email = "bob.brown@example.com",
                    Username = "bob.brown",
                    Password = _passwordManager.Secure("BrownPass101!"),
                    FullName = "Bob Brown",
                    Role = "User",
                    CreatedAt = DateTime.UtcNow.AddDays(-30)
                },
                new User
                {
                    Id = 5,
                    Email = "charlie.davis@example.com",
                    Username = "charlie.davis",
                    Password = _passwordManager.Secure("DavisPass202!"),
                    FullName = "Charlie Davis",
                    Role = "User",
                    CreatedAt = DateTime.UtcNow.AddDays(-60)
                },
                new User
                {
                    Id = 6,
                    Email = "david.wilson@example.com",
                    Username = "david.wilson",
                    Password = _passwordManager.Secure("WilsonPass303!"),
                    FullName = "David Wilson",
                    Role = "Admin",
                    CreatedAt = DateTime.UtcNow.AddDays(-150)
                }
            };

            _dbContext.Users.AddRange(users);
            await _dbContext.SaveChangesAsync();
        }
    }
}
