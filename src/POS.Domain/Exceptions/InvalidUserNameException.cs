using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions;

public sealed class InvalidUserNameException : GlobalException
{
    public string Username { get; }

    public InvalidUserNameException(string username) : base($"Username: '{username}' is invalid.")
    {
        Username = username;
    }
}
