using POS.Domain.Exceptions.Abstractions;

namespace POS.Application.Exceptions
{
    public class InvalidCredentialsException : GlobalException
    {
        public InvalidCredentialsException() : base("Invalid credentials.")
        {

        }
    }
}
