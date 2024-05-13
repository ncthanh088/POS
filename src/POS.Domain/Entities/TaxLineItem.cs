namespace POS.Domain.Entities;

public class TaxLineItem
{
    public long Id { get; set; }
    public short SequenceNumber { get; set; }
    public int TaxId { get; set; }
    public Tax Tax { get; set; }
    public decimal TaxableAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public bool? IsVoid { get; set; }
}
