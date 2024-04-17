using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public sealed record LastName
{
    public string Value { get; }

    public LastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 100 or < 3)
        {
            throw new InvalidLastNameException(value);
        }

        Value = value;
    }

    public static implicit operator LastName(string value) => new(value);

    public static implicit operator string(LastName value) => value?.Value;

    public override string ToString() => Value;
}
