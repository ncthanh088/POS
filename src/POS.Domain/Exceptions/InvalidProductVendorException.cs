using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions
{
    public class InvalidProductVendorException : GlobalException
    {
        public InvalidProductVendorException() : base("Product vendor cannot be empty.")
        {
        }
    }
}
