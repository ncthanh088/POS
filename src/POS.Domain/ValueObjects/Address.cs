using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public sealed record Address
{
    public string Value { get; }

    public Address(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidAddressException(value);
        }

        Value = value;
    }

    public static implicit operator Address(string value) => new(value);

    public static implicit operator string(Address value) => value?.Value;

    public override string ToString() => Value;
}
