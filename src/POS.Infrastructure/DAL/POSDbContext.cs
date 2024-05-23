using POS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace POS.Infrastructure.DAL;

public sealed class POSDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Tax> Taxes { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<SaleTransaction> SaleTransactions { get; set; }
    public DbSet<SaleLineItem> SaleLineItems { get; set; }
    public DbSet<TaxLineItem> TaxLineItems { get; set; }
    public DbSet<TenderLineItem> TenderLineItems { get; set; }

    public POSDbContext(DbContextOptions<POSDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings =>
        {
            warnings.Ignore(RelationalEventId.AmbientTransactionWarning);
        });
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .HasOne(item => item.Tax)
            .WithMany(tax => tax.Items)
            .HasForeignKey(item => item.TaxId);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
