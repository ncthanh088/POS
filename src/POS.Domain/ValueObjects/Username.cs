using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public sealed record Username
{
    public string Value { get; }

    public Username(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 30 or < 3)
        {
            throw new InvalidUserNameException(value);
        }

        Value = value;
    }

    public static implicit operator Username(string value) => new(value);

    public static implicit operator string(Username value) => value?.Value;

    public override string ToString() => Value;
}
