using POS.Domain.Exceptions.Abstractions;

namespace POS.Application.Exceptions;

public sealed class UsernameAlreadyInUseException : GlobalException
{
    public string Username { get; }

    public UsernameAlreadyInUseException(string username)
        : base($"Username: '{username}' is already in use.")
    {
        Username = username;
    }
}
