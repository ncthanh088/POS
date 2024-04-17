using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public record ProductDescription
{
    public string Value { get; }

    public ProductDescription(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidProductDescriptionException();
        }

        Value = value.Trim();
    }

    public static implicit operator string(ProductDescription description) => description.Value;

    public static implicit operator ProductDescription(string value) => new(value);
}
