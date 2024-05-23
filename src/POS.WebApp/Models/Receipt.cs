namespace POS.WebApp.Models;

public class Receipt
{
    public string StoreName { get; set; }
    public string Phone { get; set; }
    public string Website { get; set; }
    public string ReceiptNumber { get; set; }
    public DateTime CreateAt { get; set; }
    public string CustomerName { get; set; }
    public string ServedBy { get; set; }
    public List<ReceiptItem> Items { get; set; }
    public decimal Total => Items.Sum(item => item.Amount);
    public decimal TotalTax { get; set; }
    public decimal Discount { get; set; }

}

public class ReceiptItem
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Amount => Quantity * UnitPrice;
}
