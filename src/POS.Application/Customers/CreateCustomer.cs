using MediatR;

namespace POS.Application.Customers;

public sealed record CreateCustomer(int CustomerId,
                                    string FirstName,
                                    string LastName,
                                    string Phone,
                                    string Address) : IRequest<int>;
