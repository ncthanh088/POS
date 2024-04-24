using MediatR;
using POS.Domain.Entities;
using POS.Application.Repositories;
using POS.Application.Exceptions;

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
        var order = await _orderRepository.FindAsync(x => x.Id == request.OrderId);

        if (order is null || order.UserId != request.UserId)
        {
            throw new OrderNotFoundException(request.OrderId, request.UserId);
        }

        order.Complete();
        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}
