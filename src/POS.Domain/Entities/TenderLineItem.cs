namespace POS.Domain.Entities;

public class TenderLineItem
{
    public long Id { get; set; }
    public short SequenceNumber { get; set; }
    public string TenderTypeCode { get; set; }
    public decimal Amount { get; set; }
    public bool IsVoid { get; set; }
}
