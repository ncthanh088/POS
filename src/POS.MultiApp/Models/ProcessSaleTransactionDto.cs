namespace POS.MultiApp.Models;

public class ProcessSaleTransactionDto
{
    public long Id { get; set; }
    public bool IsComplete { get; set; }
    public bool OpenCashDrawer { get; set; }
    public long TransactionId { get; set; }
    public int WorkstationId { get; set; }
    public int TransactionNumber { get; set; }
    public long? SerialNumber { get; set; }
    public int UserId { get; set; }
    public int? CustomerId { get; set; }
    public decimal TotalExcludingTax { get; set; }
    public decimal TaxTotal { get; set; }
    public decimal Total { get; set; }
    public decimal TenderRemainingTotal { get; set; }
    public decimal ChangeAmount { get; set; }
    public decimal RoundingAmount { get; set; }
    public decimal RoundedAmount { get; set; }
    public DateTime CreateDate { get; set; }
    public IEnumerable<TransactionTax> Taxes { get; set; }
    public IEnumerable<TransactionItem> Items { get; set; }
    public IEnumerable<TransactionTender> Tenders { get; set; }
    public decimal TenderChangeAmount { get; set; }
    public string TransactionReferenceNumber { get; set; }
    public string TransactionSerialNumber { get; set; }
}
