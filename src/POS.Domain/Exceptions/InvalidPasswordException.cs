using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions;

public sealed class InvalidPasswordException : GlobalException
{
    public InvalidPasswordException() : base("Invalid password.")
    {

    }
}
