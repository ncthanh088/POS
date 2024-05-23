namespace POS.Application.Payments.Commands;

public class TransactionTax
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Percentage { get; set; }
    public decimal Amount { get; set; } // TaxAmount
    public decimal TaxableAmount { get; set; }
    public string Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
