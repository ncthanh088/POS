using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions
{
    public class InvalidItemQuantityException : GlobalException
    {
        public InvalidItemQuantityException() : base("Item quantity cannot be zero or negative.")
        {

        }
    }
}
