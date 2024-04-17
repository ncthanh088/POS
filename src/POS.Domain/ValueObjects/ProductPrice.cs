using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public sealed record ProductPrice
{
    public decimal Value { get; }

    public ProductPrice(decimal value)
    {
        if (value <= 0)
        {
            throw new InvalidProductPriceException();
        }

        Value = value;
    }

    public static implicit operator decimal(ProductPrice price) => price.Value;

    public static implicit operator ProductPrice(decimal value) => new(value);
}
