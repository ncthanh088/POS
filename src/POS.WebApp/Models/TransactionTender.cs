using POS.WebApp.Enums;

namespace POS.WebApp.Models;

public class TransactionTender
{
    public long Id { get; set; }
    public long TransactionId { get; set; }
    public short SequenceNumber { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public TenderType Type { get; set; }
}
