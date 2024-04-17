using MediatR;

namespace POS.Application.Orders.Commands;

public record CompleteOrder(Guid OrderId, Guid UserId) : IRequest;
