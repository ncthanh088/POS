using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions;

public sealed class InvalidPhoneException : GlobalException
{
    public string Phone { get; }

    public InvalidPhoneException(string phone) : base($"Phone: '{phone}' is invalid.")
    {
        Phone = phone;
    }
}
