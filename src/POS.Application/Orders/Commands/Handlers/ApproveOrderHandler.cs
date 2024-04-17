using MediatR;
using POS.Domain.Entities;
using POS.Domain.Exceptions;
using POS.Domain.ValueObjects;
using POS.Application.Repositories;

namespace POS.Application.Orders.Commands.Handlers;

internal sealed class ApproveOrderHandler : IRequestHandler<ApproveOrder>
{
    private readonly IRepository<Order> _orderRepository;

    public ApproveOrderHandler(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(ApproveOrder request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository
            .FindAsync(x => x.Id == new OrderId(request.OrderId));

        if (order == null)
            throw new OrderNotFoundException(request.OrderId);

        order.Approve();
        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}
