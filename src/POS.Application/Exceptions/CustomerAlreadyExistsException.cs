using POS.Domain.Exceptions.Abstractions;

namespace POS.Application.Exceptions;
public class CustomerAlreadyExistsException : GlobalException
{
    public Guid CustomerId { get; }

    public CustomerAlreadyExistsException(Guid customerId)
        : base($"The customer with id: '{customerId}' is already existed.")
    {
        CustomerId = customerId;
    }
}
