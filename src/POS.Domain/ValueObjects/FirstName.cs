using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public sealed record FirstName
{
    public string Value { get; }

    public FirstName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 100 or < 3)
        {
            throw new InvalidFirstNameException(value);
        }

        Value = value;
    }

    public static implicit operator FirstName(string value) => new(value);
    public static implicit operator string(FirstName value) => value?.Value;
    public override string ToString() => Value;
}
