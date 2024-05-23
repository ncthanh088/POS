namespace POS.WebApp.Models;

public class BaseSaleTransaction
{
    public long TransactionId { get; set; }
    public DateTime CreatedAt { get; set; }
    public int TransactionNumber { get; set; }
    public long? SerialNumber { get; set; }
}
