using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions
{
    public class InvalidProductDescriptionException : GlobalException
    {
        public InvalidProductDescriptionException() : base("Product description cannot be empty.")
        {

        }
    }
}
