using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public sealed record FullName
{
    public string Value { get; }

    public FullName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 100 or < 3)
        {
            throw new InvalidFullNameException(value);
        }

        Value = value;
    }

    public static implicit operator FullName(string value) => new(value);
    public static implicit operator string(FullName value) => value?.Value;
    public override string ToString() => Value;
}
