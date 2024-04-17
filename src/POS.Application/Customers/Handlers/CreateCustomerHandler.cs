using MediatR;
using POS.Application.Exceptions;
using POS.Domain.Entities;
using POS.Domain.ValueObjects;
using POS.Application.Repositories;

namespace POS.Application.Customers.Handlers;

internal sealed class CreateCustomerHandler : IRequestHandler<CreateCustomer, Guid>
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Customer> _customerRepository;
    private readonly IRepository<Cart> _cartRepository;

    public CreateCustomerHandler(IRepository<User> userRepository,
                                 IRepository<Customer> customerRepository,
                                 IRepository<Cart> cartRepository)
    {
        _userRepository = userRepository;
        _customerRepository = customerRepository;
        _cartRepository = cartRepository;
    }

    public async Task<Guid> Handle(CreateCustomer request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(x => x.Id == new UserId(request.CustomerId));
        if (user is null)
        {
            throw new UserNotFoundException(request.CustomerId);
        }

        if (user.Role != "user")
        {
            return Guid.Empty;
        }

        var customerId = user.Id;
        // var currentcustomer = await _customerRepository.FindAsync(x => x.CustomerId == customerId);
        if (await _customerRepository.FindAsync(x => x.CustomerId == customerId) is not null)
        {
            throw new CustomerAlreadyExistsException(customerId);
        }

        var cart = new Cart(user.Id);
        await _cartRepository.AddAsync(cart);

        var customer = new Customer(customerId, request.FirstName, request.LastName, request.Phone, request.Address);
        await _customerRepository.AddAsync(customer);
        return user.Id;
    }
}
