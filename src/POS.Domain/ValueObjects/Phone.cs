using System.Text.RegularExpressions;
using POS.Domain.Exceptions;

namespace POS.Domain.ValueObjects;

public sealed record Phone
{
    // private static readonly Regex s_regex = new(@"^[2-9]{2}[0-9]{8}$", RegexOptions.Compiled);

    public string Value { get; }

    public Phone(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 11 or < 8)
        {
            throw new InvalidPhoneException(value);
        }

        // if (!s_regex.IsMatch(value))
        // {
        //     throw new InvalidPhoneException(value);
        // }

        Value = value;
    }

    public static implicit operator Phone(string value) => new(value);
    public static implicit operator string(Phone value) => value?.Value;

    public override string ToString() => Value;
}
