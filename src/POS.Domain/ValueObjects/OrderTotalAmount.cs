using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public sealed record OrderTotalAmount
{
    public decimal Value { get; }

    public OrderTotalAmount(decimal value)
    {
        if (value < 0)
        {
            throw new InvalidOrderTotalAmountException();
        }

        Value = value;
    }

    public static implicit operator decimal(OrderTotalAmount amount) => amount;

    public static implicit operator OrderTotalAmount(decimal value) => new(value);
}
