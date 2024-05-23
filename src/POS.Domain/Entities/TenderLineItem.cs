using POS.Domain.Enums;

namespace POS.Domain.Entities;

public class TenderLineItem
{
    public long Id { get; set; }
    public long TransactionId { get; set; }
    public short SequenceNumber { get; set; }
    public TenderType TenderType { get; set; }
    public decimal Amount { get; set; }
    public bool IsVoid { get; set; }
}
