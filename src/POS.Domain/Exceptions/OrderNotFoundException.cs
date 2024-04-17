using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions
{
    public class OrderNotFoundException : GlobalException
    {
        public Guid OrderId { get; set; }
        public OrderNotFoundException(Guid orderId) : base($"Order with Id: '{orderId}' was not found.")
        {
            OrderId = orderId;
        }
    }
}
