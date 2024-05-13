using POS.Domain.Enums;

namespace POS.Domain.Entities
{
    public class SaleTransaction
    {
        public long Id { get; set; }
        public int WorkstationId { get; set; }
        public int UserId { get; set; }
        public int? CustomerId { get; set; }
        public int TransactionNumber { get; set; }
        public TransactionType Type { get; set; } = TransactionType.Sale;
        public DateTime CreatedAt { get; set; }
        public long? SerialNumber { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsVoided { get; set; }
        public bool IsRefund { get; set; }
    }
}
