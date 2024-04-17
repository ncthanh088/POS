using MediatR;
using POS.Application.Exceptions;
using POS.Domain.Entities;
using POS.Domain.ValueObjects;
using POS.Domain.Repositories;

namespace POS.Application.Orders.Commands.Handlers;

internal sealed class CompleteOrderHandler : IRequestHandler<CompleteOrder>
{
    private readonly IRepository<Order> _orderRepository;

    public CompleteOrderHandler(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(CompleteOrder request, CancellationToken cancellationToken)
    {
        var orderId = new OrderId(request.OrderId);
        var order = await _orderRepository.FindAsync(x => x.Id == orderId);

        if (order is null || order.UserId != new UserId(request.UserId))
        {
            throw new OrderNotFoundException(request.OrderId, request.UserId);
        }

        order.Complete();
        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}
