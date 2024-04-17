using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public sealed record CartId
{
    public Guid Value { get; }

    public CartId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static implicit operator Guid(CartId id) => id.Value;

    public static implicit operator CartId(Guid value) => new(value);
}
