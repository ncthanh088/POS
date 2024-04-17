using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions;

public sealed class InvalidAddressException : GlobalException
{
    public string Address { get; }

    public InvalidAddressException(string address) : base($"Address: '{address}' is invalid.")
    {
        Address = address;
    }
}
