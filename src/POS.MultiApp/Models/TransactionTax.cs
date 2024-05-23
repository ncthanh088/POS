namespace POS.MultiApp.Models;

public class TransactionTax
{
    public int Id { get; set; }
    public long TransactionId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Percentage { get; set; }
    public decimal Amount { get; set; }
    public decimal TaxableAmount { get; set; }
    public string Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
