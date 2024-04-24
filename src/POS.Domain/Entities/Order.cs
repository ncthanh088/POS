using POS.Domain.Enums;
using POS.Domain.Exceptions;

namespace POS.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid UserId { get; private set; }
    public IEnumerable<Item> Items { get; private set; }
    public decimal TotalAmount { get; private set; }
    public string Currency { get; private set; }
    public OrderStatus Status { get; private set; }

    protected Order()
    {
    }

    public Order(Guid id, Guid userId, IEnumerable<Item> items, string currency)
    {
        if (items == null || !items.Any())
        {
            throw new InvalidOrderException($"Cannot create an order for an empty cart for customer with id: '{userId}'.");
        }
        Id = id;
        UserId = userId;
        Items = items;
        Currency = currency;
        Status = OrderStatus.Created;
        TotalAmount = Items.Sum(i => i.TotalPrice);
    }

    public void Approve()
    {
        Status = Status switch
        {
            OrderStatus.Approved => throw new InvalidOrderException($"Cannot approve an approved order with id: '{Id}'."),
            OrderStatus.Canceled => throw new InvalidOrderException($"Cannot approve a canceled order with id: '{Id}'."),
            OrderStatus.Revoked => throw new InvalidOrderException($"Cannot approve a revoked order with id: '{Id}'."),
            OrderStatus.Completed => throw new InvalidOrderException($"Cannot approve a completed order with id: '{Id}'."),
            _ => OrderStatus.Approved,
        };
    }

    public void Complete()
    {
        if (Status != OrderStatus.Approved)
        {
            throw new InvalidOrderException($"Cannot complete not approved order with id: '{Id}'.");
        }

        Status = Status switch
        {
            OrderStatus.Canceled => throw new InvalidOrderException($"Cannot complete a canceled order with id: '{Id}'."),
            OrderStatus.Revoked => throw new InvalidOrderException($"Cannot complete a revoked order with id: '{Id}'."),
            OrderStatus.Completed => throw new InvalidOrderException($"Cannot complete an already completed order with id: '{Id}'."),
            _ => OrderStatus.Completed,
        };
    }

    public void Cancel()
    {
        Status = Status switch
        {
            OrderStatus.Canceled => throw new InvalidOrderException($"Cannot cancel an already canceled order with id: '{Id}'"),
            OrderStatus.Revoked => throw new InvalidOrderException($"Cannot cancel a revoked order with id: '{Id}'."),
            OrderStatus.Completed => throw new InvalidOrderException($"Cannot cancel a completed order with id: '{Id}'"),
            _ => OrderStatus.Canceled,
        };
    }

    public void Revoke()
    {
        Status = Status switch
        {
            OrderStatus.Revoked => throw new InvalidOrderException($"Cannot revoke an already revoked order with id: '{Id}'"),
            _ => OrderStatus.Revoked,
        };
    }
}
