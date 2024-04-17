using MediatR;

namespace POS.Application.Customers;

public sealed record CreateCustomer(Guid CustomerId,
                                    string FirstName,
                                    string LastName,
                                    string Phone,
                                    string Address) : IRequest<Guid>;
