using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions
{
    public sealed class InvalidRoleException : GlobalException
    {
        public string Role { get; }

        public InvalidRoleException(string role) : base($"Role: '{role}' is invalid.")
        {
            Role = role;
        }
    }
}
