namespace POS.MultiApp.Models;

public class CartInfo
{
    public long TransactionId { get; set; }
    public decimal SubTotal
    {
        get
        {
            return CartItems == null ? 0M : CartItems.Sum(x => x.ActualUnitPrice * x.Quantity);
        }
    }

    public decimal TotalDiscount
    {
        get
        {
            return Discounts == null ? 0M : Discounts.Sum(x => x.Amount);
        }
    }
    public decimal TotalTax
    {
        get
        {
            return Taxes == null ? 0M : Taxes.Sum(x => x.Amount);
        }
    }
    public decimal Total
    {
        get
        {
            return SubTotal - TotalDiscount + TotalTax;
        }
    }
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public ICollection<Discount> Discounts { get; set; } = new List<Discount>();
    public ICollection<TransactionTender> Tenders { get; set; } = new List<TransactionTender>();
    public ICollection<TransactionTax> Taxes { get; set; } = new List<TransactionTax>();
}
