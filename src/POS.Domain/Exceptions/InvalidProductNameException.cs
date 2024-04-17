using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions
{
    public class InvalidProductNameException : GlobalException
    {
        public InvalidProductNameException() : base("Product name cannot be empty.")
        {

        }
    }
}
