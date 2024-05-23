namespace POS.Application.Payments.Commands;

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
    public decimal BeforeDiscountPriceExcludingTax
    {
        get
        {
            decimal p = BeforeDiscountUnitPrice.HasValue ? BeforeDiscountUnitPrice.Value : ActualUnitPrice;
            if (p == decimal.Zero)
            {
                return p;
            }
            else
            {
                var tax = CalculateOrigTaxBeforeVATExemption(p);
                return decimal.Subtract(p, tax);
            }
        }
    }
    public decimal RegularUnitPrice { get; set; } = 0M;
    public decimal TotalTax { get; set; }
    public bool TaxOnGrossAmount { get; set; }
    public decimal ExtendedDiscountAmount { get; set; }
    public decimal ExtendedPriceExcludingDiscount { get; set; }
    private decimal? _actualUnitPrice { get; set; }
    public decimal ActualUnitPrice
    {
        get
        {
            var price = _actualUnitPrice ?? RegularUnitPrice;
            return Math.Round(price, 2);
        }
        set
        {
            _actualUnitPrice = value;
            UpdateTotal();
        }
    }
    public decimal ActualPriceExcludingTax
    {
        get
        {
            if (ActualUnitPrice == decimal.Zero)
            {
                return ActualUnitPrice;
            }
            else
            {
                var tax = CalculateTax(ActualUnitPrice);
                return decimal.Subtract(ActualUnitPrice, tax);
            }

        }
    }

    private decimal _extendedPrice { get; set; }
    public decimal TotalPrice
    {
        get
        {
            return _extendedPrice;
        }
    }

    public decimal TotalPriceExcludingTax
    {
        get
        {
            return decimal.Subtract(TotalPrice, TotalTax);
        }
    }

    public void UpdateTotal()
    {
        _extendedPrice = ActualUnitPrice * Quantity;
        TotalTax = CalculateTax(TotalPrice);
    }

    public decimal CalculateOrigTaxBeforeVATExemption(decimal grossAmount)
    {
        return CalculateTax(grossAmount);
    }

    public decimal CalculateTax(decimal grossAmount)
    {
        var taxPercentage = Tax.Amount;
        var taxRate = 1 - (1 / (1 + (taxPercentage / 100)));
        if (TaxOnGrossAmount)
        {
            taxRate = taxPercentage / 100;
        }
        var taxAmount = Math.Round(grossAmount * taxRate, 2);

        return taxAmount;
    }
}
