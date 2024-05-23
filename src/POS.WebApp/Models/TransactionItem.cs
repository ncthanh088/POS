namespace POS.WebApp.Models;

public class TransactionItem
{
    public long Id { get; set; }
    public long TransactionId { get; set; }
    public int ItemId { get; set; }
    public string Name { get; set; }
    public short SequenceNumber { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public Tax Tax { get; set; }
    public Discount Discount { get; set; }
    public decimal? BeforeDiscountUnitPrice { get; set; }
    public decimal BeforeDiscountPriceExcludingTax { get; set; }
    public decimal RegularUnitPrice { get; set; } = 0M;
    public decimal TotalTax { get; set; }
    public bool TaxOnGrossAmount { get; set; }
    public decimal ExtendedDiscountAmount { get; set; }
    public decimal ExtendedPriceExcludingDiscount { get; set; }
    public decimal ActualUnitPrice { get; set; }
    public decimal ActualPriceExcludingTax { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal TotalPriceExcludingTax { get; set; }
}
