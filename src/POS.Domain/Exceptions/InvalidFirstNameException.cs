using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions;

public sealed class InvalidFirstNameException : GlobalException
{
    public string FirstName { get; }

    public InvalidFirstNameException(string firstName) : base($"FirstName: '{firstName}' is invalid.")
    {
        FirstName = firstName;
    }
}
