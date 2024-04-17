using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions;

public sealed class InvalidLastNameException : GlobalException
{
    public string LastName { get; }

    public InvalidLastNameException(string lastName) : base($"LastName: '{lastName}' is invalid.")
    {
        LastName = lastName;
    }
}
