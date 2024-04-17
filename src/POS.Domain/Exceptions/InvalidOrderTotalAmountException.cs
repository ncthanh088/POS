using POS.Domain.Exceptions.Abstractions;

namespace POS.Domain.Exceptions
{
    public class InvalidOrderTotalAmountException : GlobalException
    {
        public InvalidOrderTotalAmountException() : base("Order total amount cannot be negative.")
        {

        }
    }
}
