using POS.Domain.Enums;

namespace POS.Domain.Entities;

public class Tender
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public TenderType Type { get; set; }
}
