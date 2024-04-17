using MediatR;

namespace POS.Application.Orders.Commands;

public record CreateOrder(Guid OrderId, Guid UserId) : IRequest;

