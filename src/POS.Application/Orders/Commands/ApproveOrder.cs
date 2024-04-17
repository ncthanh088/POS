using MediatR;

namespace POS.Application.Orders.Commands;

public record ApproveOrder(Guid OrderId) : IRequest;
