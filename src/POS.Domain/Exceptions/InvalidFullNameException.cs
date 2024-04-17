using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions;

public sealed class InvalidFullNameException : GlobalException
{
    public string FullName { get; }

    public InvalidFullNameException(string fullName) : base($"FullName: '{fullName}' is invalid.")
    {
        FullName = fullName;
    }
}
