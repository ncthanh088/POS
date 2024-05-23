using POS.Domain.Exceptions.Abstractions;

namespace POS.Application.Exceptions;
public class CustomerAlreadyExistsException : GlobalException
{
    public int CustomerId { get; }

    public CustomerAlreadyExistsException(int customerId)
        : base($"The customer with id: '{customerId}' is already existed.")
    {
        CustomerId = customerId;
    }
}
