using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public sealed record OrderId
{
    public Guid Value { get; }

    public OrderId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static implicit operator Guid(OrderId id) => id.Value;

    public static implicit operator OrderId(Guid value) => new(value);
}
