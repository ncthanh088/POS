using POS.Domain.Exceptions.Abstractions;

namespace POS.Application.Exceptions;

public sealed class EmailAlreadyInUseException : GlobalException
{
    public string Email { get; }

    public EmailAlreadyInUseException(string email)
        : base($"Email: '{email}' is already in use.")
    {
        Email = email;
    }
}
