using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public sealed record Currency
{

    public string Value { get; }

    public Currency(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidCurrencyException(value);
        }

        Value = value;
    }

    public static implicit operator string(Currency currency) => currency.Value;

    public static implicit operator Currency(string currency) => new(currency);

    public override string ToString() => Value;
}
