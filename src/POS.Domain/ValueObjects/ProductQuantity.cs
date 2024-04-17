using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public sealed record ProductQuantity
{
    public int Value { get; }

    public ProductQuantity(int value)
    {
        if (value < 0)
        {
            throw new InvalidProductQuantityException();
        }

        Value = value;
    }

    public static implicit operator int(ProductQuantity quantity) => quantity.Value;

    public static implicit operator ProductQuantity(int value) => new(value);
}
