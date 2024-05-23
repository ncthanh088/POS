using System.Text.Json.Serialization;

namespace POS.WebApp.Models;

public class CartItem
{
    public int Id { get; set; }
    public long TransactionId { get; set; }
    public short SequenceNumber { get; set; }

    public string Name { get; set; }
    public int ItemId { get; set; }
    public int CustomerId { get; set; }

    [JsonIgnore]
    public Item Item { get; set; }
    public decimal UnitPrice { get; set; }
    public int TaxIdentity { get; set; }

    public decimal RegularUnitPrice { get; set; } = 0M;
    public decimal ActualUnitPrice { get; set; }
    public decimal ExtendedPrice { get; set; }
    public decimal TaxAmount { get; set; }
    public bool IsMemberBenefit { get; set; }
    public bool IsVocher { get; set; }
    public int Quantity { get; set; } = 0;

    [JsonIgnore]
    public decimal TotalPrice => Quantity * UnitPrice;

    public Tax Tax { get; set; }
    public Discount Discount { get; set; }
    public decimal? BeforeDiscountUnitPrice { get; set; }
    public decimal BeforeDiscountPriceExcludingTax { get; set; }
    public decimal TotalTax { get; set; }
    public bool TaxOnGrossAmount { get; set; }
    public decimal ExtendedDiscountAmount { get; set; }
    public decimal ExtendedPriceExcludingDiscount { get; set; }
    public decimal ActualPriceExcludingTax { get; set; }
    public decimal TotalPriceExcludingTax { get; set; }
}
