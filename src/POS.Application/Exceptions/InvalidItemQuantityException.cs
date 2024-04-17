using POS.Domain.Exceptions.Abstractions;

namespace POS.Application.Exceptions
{
    public class InvalidItemQuantityException : GlobalException
    {
        public InvalidItemQuantityException() : base($"Item quantity cannot be negative or zero.")
        {

        }
    }
}
