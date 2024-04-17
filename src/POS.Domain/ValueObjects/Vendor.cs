using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public record Vendor
{
    public string Value { get; }

    public Vendor(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidProductVendorException();
        }

        Value = value.Trim().ToLowerInvariant(); ;
    }

    public static implicit operator string(Vendor vendor)
        => vendor.Value;

    public static implicit operator Vendor(string value)
        => new(value);
}
