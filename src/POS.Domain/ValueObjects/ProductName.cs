using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public record ProductName
{
    public string Value { get; }

    public ProductName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidProductNameException();
        }

        Value = value.Trim().ToLowerInvariant();
    }

    public static implicit operator string(ProductName name)
        => name.Value;
    public static implicit operator ProductName(string name)
        => new(name);
}
