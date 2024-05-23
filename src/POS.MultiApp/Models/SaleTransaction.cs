namespace POS.MultiApp.Models
{
    public class SaleTransaction
    {
        public int UserId { get; set; }
        public int? CustomerId { get; set; }
        public long TransactionId { get; set; }
        public int WorkstationId { get; set; }
        public int TransactionNumber { get; set; }
        public long? SerialNumber { get; set; }
        public string Description { get; set; }
        public int Type { get; set; } = 0;
        public bool OpenCashDrawer { get; set; }
        public int TaxId { get; set; }
        public decimal Total { get; set; }
        public decimal TotalTax { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsVoided { get; set; }
        public bool IsComplete { get; set; }
        public decimal TotalExcludingTax { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal TenderTotal { get; set; }
        public decimal TenderRemainingTotal { get; set; }
        public decimal ChangeAmount { get; set; }
        public decimal RoundingAmount { get; set; }
        public decimal RoundedAmount { get; set; }
        public IEnumerable<TransactionTax> Taxes { get; set; }
        public IEnumerable<TransactionItem> Items { get; set; }
        public IEnumerable<TransactionTender> Tenders { get; set; }
        public DateTime CreatedAt { get; set; }
        public string TransactionReferenceNumber { get; set; }
        public string TransactionSerialNumber { get; set; }
    }
}
