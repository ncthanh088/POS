using MediatR;
using POS.Domain.ValueObjects;

namespace POS.Application.Orders.Commands;

public record CancelOrder(Guid OrderId, Guid UserId) : IRequest;
