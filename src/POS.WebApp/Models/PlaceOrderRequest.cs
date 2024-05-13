using POS.WebApp.Enums;

namespace POS.WebApp.Models;

public class PlaceOrderRequest
{
    public Guid OrderId { get; set; }
    public Guid UserId { get; set; }
    public Guid? CustomerId { get; set; }
    public IEnumerable<Item> Items { get; set; }
    public DateTime CreatedDate { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
}
