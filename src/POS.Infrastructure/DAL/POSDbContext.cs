using POS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace POS.Infrastructure.DAL;

public sealed class POSDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Tax> Taxes { get; set; }

    public POSDbContext(DbContextOptions<POSDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.HasDefaultSchema("pos-database");
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
