using MediatR;
using POS.Application.Exceptions;
using POS.Domain.Entities;
using POS.Application.Repositories;

namespace POS.Application.Customers.Handlers;

internal sealed class CreateCustomerHandler : IRequestHandler<CreateCustomer, int>
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Customer> _customerRepository;

    public CreateCustomerHandler(IRepository<User> userRepository, IRepository<Customer> customerRepository)
    {
        _userRepository = userRepository;
        _customerRepository = customerRepository;
    }

    public async Task<int> Handle(CreateCustomer request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(x => x.Id == request.CustomerId);
        if (user is null)
        {
            throw new UserNotFoundException(request.CustomerId);
        }

        if (user.Role != "User")
        {
            return int.MinValue;
        }

        var customerId = user.Id;
        if (await _customerRepository.FindAsync(x => x.Id == customerId) is not null)
        {
            throw new CustomerAlreadyExistsException(customerId);
        }

        var customer = new Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Phone = request.Phone,
            Address = request.Address,
        };
        await _customerRepository.AddAsync(customer);
        return user.Id;
    }
}
