using MediatR;
using POS.Domain.Entities;
using POS.Application.DTO;
using POS.Application.Repositories;

namespace POS.Application.Orders.Queries.Handlers;

internal sealed class BrowseOrdersHandler : IRequestHandler<BrowseOrders, IEnumerable<OrderDto>>
{
    private readonly IRepository<Order> _orderRepository;

    public BrowseOrdersHandler(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<OrderDto>> Handle(BrowseOrders request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository
            .FindAllAsync(x => x.UserId == request.UserId);

        return orders.Select(x => x.AsDto());
    }
}
