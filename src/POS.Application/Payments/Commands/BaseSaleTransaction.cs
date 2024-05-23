using POS.Domain.Enums;
using System.Text;
using System.Globalization;

namespace POS.Application.Payments.Commands;

public class BaseSaleTransaction
{
    public int UserId { get; set; }
    public int? CustomerId { get; set; }
    public long TransactionId { get; set; }
    public int WorkstationId { get; set; }
    public int TransactionNumber { get; set; }
    public long? SerialNumber { get; set; }
    public string Description { get; set; }
    public TransactionType? Type { get; set; } = TransactionType.Sale;
    public bool OpenCashDrawer { get; set; }
    public int TaxId { get; set; }
    public decimal Total { get; set; }
    public decimal TotalTax { get; set; }
    public bool IsCancelled { get; set; }
    public bool IsVoided { get; set; }
    public bool IsComplete { get; set; }
    public decimal TotalExcludingTax
    {
        get
        {
            return Total - TaxTotal;
        }
    }
    public decimal TaxTotal
    {
        get
        {
            return Items?.Sum(x => x.TotalTax) ?? 0M;
        }
    }

    public decimal TenderTotal
    {
        get
        {
            return Tenders?.Select(x => x.Amount).Sum() ?? 0M;
        }
    }
    public decimal TenderRemainingTotal
    {
        get
        {
            return RoundedAmount > TenderTotal ? RoundedAmount - TenderTotal : 0M;
        }
    }
    public decimal ChangeAmount
    {
        get
        {
            return IsComplete ? TenderTotal - RoundedAmount : 0;
        }
    }
    public decimal RoundingAmount { get; set; } = decimal.Zero;
    public decimal RoundedAmount
    {
        get
        {
            return Total + RoundingAmount;
        }
    }

    public IEnumerable<TransactionTax> Taxes { get; set; }
    public ICollection<TransactionItem> Items { get; set; }
    public ICollection<TransactionTender> Tenders { get; set; }
    public DateTime CreatedAt { get; set; }

    public string TransactionReferenceNumber
    {
        get
        {
            var referenceNumber = new StringBuilder();
            referenceNumber.AppendFormat("{0:000}", WorkstationId);
            referenceNumber.AppendFormat(CultureInfo.InvariantCulture, "{0:yy}", CreatedAt);
            referenceNumber.AppendFormat(CultureInfo.InvariantCulture, "{0:00}", CreatedAt.Month);
            referenceNumber.AppendFormat(CultureInfo.InvariantCulture, "{0:00}", CreatedAt.Day);
            referenceNumber.AppendFormat("{0:0000}", TransactionNumber);
            return referenceNumber.ToString();
        }
    }

    public string TransactionSerialNumber
    {
        get
        {
            return SerialNumber.HasValue
                       ? string.Format("{0:D3}{1:D13}", WorkstationId, SerialNumber)
                       : string.Empty;
        }
    }
}
