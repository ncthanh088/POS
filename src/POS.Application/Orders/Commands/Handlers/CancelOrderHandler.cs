using MediatR;
using POS.Domain.Entities;
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
        var order = await _orderRepository.FindAsync(x => x.Id == request.OrderId);
        if (order == null || order.UserId != request.UserId)
        {
            throw new OrderNotFoundException(request.OrderId, request.UserId);
        }

        order.Cancel();
        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}
