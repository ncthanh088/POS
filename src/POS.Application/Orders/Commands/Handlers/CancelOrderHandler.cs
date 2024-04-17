using MediatR;
using POS.Domain.Entities;
using POS.Domain.ValueObjects;
using POS.Application.Exceptions;
using POS.Application.Repositories;

namespace POS.Application.Orders.Commands.Handlers;

internal sealed class CancelOrderHandler : IRequestHandler<CancelOrder>
{
    private readonly IRepository<Order> _orderRepository;

    public CancelOrderHandler(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(CancelOrder request, CancellationToken cancellationToken)
    {
        var orderId = new OrderId(request.OrderId);
        var order = await _orderRepository.FindAsync(x => x.Id == orderId);

        var userId = new UserId(request.UserId);
        if (order == null || order.UserId != userId)
        {
            throw new OrderNotFoundException(request.OrderId, request.UserId);
        }

        order.Cancel();
        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}
