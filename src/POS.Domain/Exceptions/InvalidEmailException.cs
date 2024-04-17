using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions
{
    public sealed class InvalidEmailException : GlobalException
    {
        public string Email { get; }

        public InvalidEmailException(string email) : base($"Email: '{email}' is invalid.")
        {
            Email = email;
        }
    }
}
