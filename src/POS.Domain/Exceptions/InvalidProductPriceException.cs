using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions
{
    public class InvalidProductPriceException : GlobalException
    {
        public InvalidProductPriceException() : base("Product price cannot be zero or negative.")
        {

        }
    }
}
