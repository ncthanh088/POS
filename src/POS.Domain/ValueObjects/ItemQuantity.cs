using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public sealed record ItemQuantity
{
    public int Value { get; }

    public ItemQuantity(int value)
    {
        if (value <= 0)
        {
            throw new InvalidItemQuantityException();
        }

        Value = value;
    }

    public static implicit operator int(ItemQuantity quantity) => quantity.Value;
    public static implicit operator ItemQuantity(int value) => new(value);
}
