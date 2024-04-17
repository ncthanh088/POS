using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions
{
    public class InvalidOrderException : GlobalException
    {
        public InvalidOrderException(string message) : base(message)
        {

        }
    }
}
