using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions
{
    public class InvalidProductQuantityException : GlobalException
    {
        public InvalidProductQuantityException() : base("Product quantity cannot be negative.")
        {

        }
    }
}
