using System.Globalization;
using System.Text;
using POS.Domain.Enums;

namespace POS.Application.Payments.Commands;

public class BaseSaleTransaction
{
    public Guid UserId { get; set; }
    public Guid? CustomerId { get; set; }
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
    public decimal RoundingAmount { get; set; } = 0M;
    public decimal RoundedAmount
    {
        get
        {
            return Total + RoundingAmount;
        }
    }

    public IEnumerable<TransactionItem> Items { get; set; }
    public IEnumerable<TransactionTax> Taxes { get; set; }
    public IEnumerable<TransactionTender> Tenders { get; set; }
    public DateTime CreatedDate { get; set; }

    public string TransactionReferenceNumber
    {
        get
        {
            var referenceNumber = new StringBuilder();
            referenceNumber.AppendFormat("{0:000}", WorkstationId);
            referenceNumber.AppendFormat(CultureInfo.InvariantCulture, "{0:yy}", CreatedDate);
            referenceNumber.AppendFormat(CultureInfo.InvariantCulture, "{0:00}", CreatedDate.Month);
            referenceNumber.AppendFormat(CultureInfo.InvariantCulture, "{0:00}", CreatedDate.Day);
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
