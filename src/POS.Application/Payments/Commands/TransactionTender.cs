using POS.Domain.Enums;

namespace POS.Application.Payments.Commands;

public class TransactionTender
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public TenderType Type { get; set; }
}
