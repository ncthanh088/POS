using MediatR;

namespace POS.Application.Orders.Commands;

public record CancelOrder(Guid OrderId, Guid UserId) : IRequest;
