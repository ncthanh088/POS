using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public sealed record ProductId
{
    public Guid Value { get; }

    public ProductId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static implicit operator Guid(ProductId id) => id.Value;

    public static implicit operator ProductId(Guid value) => new(value);
}
