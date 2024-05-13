namespace POS.Application.DTO;

public class SaleLineItemDto
{
    public int Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public TaxDto Tax { get; set; }
    public DiscountDto? Discount { get; set; }
}
