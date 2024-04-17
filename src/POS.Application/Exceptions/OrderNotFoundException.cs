using POS.Domain.Exceptions.Abstractions;

namespace POS.Application.Exceptions
{
    public sealed class OrderNotFoundException : GlobalException
    {
        public Guid OrderId { get; }
        public Guid UserId { get; }

        public OrderNotFoundException(Guid orderId, Guid userId)
            : base($"Order with id: '{orderId}' was not found for customer with id: '{userId}'.")
        {
            OrderId = orderId;
            UserId = userId;
        }

    }
}
