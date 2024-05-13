using System.Transactions;

namespace POS.Domain.Entities;

public class SaleLineItem
{
    public long Id { get; set; }
    public short SequenceNumber { get; set; }
    public int ItemId { get; set; }
    public decimal UnitPrice { get; set; }
    public int TaxIdentity { get; set; }
    public decimal RegularUnitPrice { get; set; }
    public decimal ActualUnitPrice { get; set; }
    public decimal Quantity { get; set; }
    public decimal ExtendedPrice { get; set; }
    public decimal TaxAmount { get; set; }
    public int? DiscountId { get; set; }
    public bool? IsMemberBenefit { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
}
